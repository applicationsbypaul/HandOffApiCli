select * from Employees e
join JobDetails j on e.Employee_JobDetailId = j.JobDetailId
join Patients p on p.Patient_EmployeeId = e.EmployeeId
join Visits v on v.Visit_PatientId = p.PatientId

select * from JobDetails

select * from Patients 

select * from Visits