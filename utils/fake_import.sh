#!/bin/bash

db_path=$XDG_DATA_HOME/students.db
project_path=../StudentManagement
 

print_success () {
	printf "SUCCESS\n\n"
}

echo "CREATING DATABASE IN ${db_path}"
touch $db_path
print_success

echo "RUNNING MIGRATIONS"
./dotnet-ef database update --project ${project_path} --no-build
print_success

folder="../utils/fake_data";
# declare tables specifically to create relations in the right order 
tables=("users teachers" "groups" "courses" "students" "marks" "absences")
for table in ${tables[@]}
do
	file_name=$folder/$table.csv
	table_name=$(echo "${table}" | sed -e "s/\b\(.\)/\u\1/g")
	echo "IMPORTING FAKE DATA INTO TABLE ${table_name} FROM FILE ${file_name}"
	sqlite3 ${db_path} ".mode csv" ".import ${file_name} ${table_name}" ".exit"
done
print_success
