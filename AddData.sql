Select p.id, * from Patients p 
Left Join Visits v on v.id = p.patient_visitid

select * from Visits

INSERT INTO Patients (patient_fname, patient_lname, patient_city, patient_phone, patient_visitid, patient_primary_care_id)
VALUES ('Paul', 'Ford', 'Chicago', null,null, null);

INSERT INTO Patients (patient_fname, patient_lname, patient_city, patient_phone, patient_visitid, patient_primary_care_id)
VALUES ('Steve', 'Ford', 'Ames', null,null, null);

INSERT INTO Visits (visit_date, visit_handoff_id, work_group_id)
Values (GetDate(),null, null)

Alter table Patients 
set patient_visitid = 

DROP Database TestDB


migrationBuilder.Sql("INSERT INTO Patients (patient_fname, patient_lname, patient_city, patient_phone, patient_visitid, patient_primary_care_id)\r\nVALUES ('Paul', 'Ford', 'Chicago', null,null, null);");
migrationBuilder.Sql("INSERT INTO Patients (patient_fname, patient_lname, patient_city, patient_phone, patient_visitid, patient_primary_care_id)\r\nVALUES ('Steve', 'Ford', 'Ames', null,null, null);");
migrationBuilder.Sql("INSERT INTO Visits (visit_date, visit_handoff_id, work_group_id)\r\nValues (GetDate(),null, null);");