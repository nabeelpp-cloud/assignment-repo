-- Healthcare System Schema
create database AssignmentDay7
use AssignmentDay7

CREATE TABLE Patients (
    PatientID INT PRIMARY KEY,
    PatientName VARCHAR(100),
    DateOfBirth DATE,
    Gender VARCHAR(10)
);

CREATE TABLE Doctors (
    DoctorID INT PRIMARY KEY,
    DoctorName VARCHAR(100),
    Specialty VARCHAR(100)
);

CREATE TABLE Appointments (
    AppointmentID INT PRIMARY KEY,
    PatientID INT,
    DoctorID INT,
    AppointmentDate DATE,
    FOREIGN KEY (PatientID) REFERENCES Patients(PatientID),
    FOREIGN KEY (DoctorID) REFERENCES Doctors(DoctorID)
);

CREATE TABLE Medications (
    MedicationID INT PRIMARY KEY,
    MedicationName VARCHAR(200),
    DosageForm VARCHAR(50)
);

CREATE TABLE Prescriptions (
    PrescriptionID INT PRIMARY KEY,
    PatientID INT,
    MedicationID INT,
    PrescriptionDate DATE,
    FOREIGN KEY (PatientID) REFERENCES Patients(PatientID),
    FOREIGN KEY (MedicationID) REFERENCES Medications(MedicationID)
);

-- Questions

-- 1. List all patients and their appointments, including patients who have never had an appointment.

SELECT 
	p.PatientID,p.PatientName,a.AppointmentID,a.AppointmentDate 
FROM 
	Patients p LEFT JOIN Appointments a 
ON 
	p.PatientID=a.PatientID;

-- 2. Display all doctors and their scheduled appointments, including doctors without any appointments.

SELECT 
	d.DoctorID,d.DoctorName,a.AppointmentID,a.AppointmentDate 
FROM 
	Doctors d LEFT JOIN Appointments a 
ON 
	d.DoctorID=a.DoctorID

-- 3. Show all medications and the patients they've been prescribed to, including medications that haven't been prescribed.

SELECT 
	m.MedicationID,m.MedicationName,pa.PatientName 
FROM 
	Medications m LEFT JOIN Prescriptions p 
ON 
	p.MedicationID=m.MedicationID LEFT JOIN Patients pa  
ON 
	pa.PatientID=p.PatientID

-- 4. List all possible patient-doctor combinations, regardless of whether an appointment has occurred.

SELECT 
	p.PatientName,d.DoctorName 
FROM 
	Patients p CROSS JOIN Doctors d

-- 5. Display all prescriptions with patient and medication information, including prescriptions where either the patient or medication information is missing.

SELECT 
	pr.PrescriptionID,pa.PatientID,pa.PatientName,med.MedicationID,med.MedicationName
FROM 
	Prescriptions pr 
FULL OUTER JOIN  
	Patients pa ON pa.PatientID=pr.PatientID 
FULL OUTER JOIN 
	Medications med ON med.MedicationID=pr.MedicationID

-- 6. Show all patients who have never been prescribed any medication, along with their appointment history.

SELECT 
	pa.PatientName , app.AppointmentID,app.AppointmentDate
FROM 
	Patients pa 
LEFT JOIN 
	Prescriptions pr ON pa.PatientID=pr.PatientID 
LEFT JOIN 
	Appointments app ON  app.PatientID=pa.PatientID
WHERE 
	pr.MedicationID IS NULL

-- 7. List all doctors who have appointments in the next week, along with the patients they're scheduled to see.

SELECT 
    dr.DoctorName,pa.PatientName,app.AppointmentDate
FROM Doctors dr
JOIN Appointments app ON dr.DoctorID = app.DoctorID
JOIN Patients pa ON pa.PatientID = app.PatientID
WHERE app.AppointmentDate BETWEEN GETDATE() AND DATEADD(DAY, 7, GETDATE());

-- 8. Display all medications prescribed to patients over 60 years old, including medications not prescribed to this age group.

SELECT 
    med.MedicationName
FROM 
	Medications med LEFT JOIN Prescriptions pr 
ON 
	pr.MedicationID = med.MedicationID LEFT JOIN Patients pa 
ON pa.PatientID = pr.PatientID AND (YEAR(GETDATE()) - YEAR(pa.DateOfBirth)) > 60;

-- 9. Show all appointments from last year and any associated prescription information.

SELECT 
	app.AppointmentID,app.AppointmentDate,pr.PatientID,med.MedicationName
FROM 
	Appointments app LEFT JOIN Prescriptions pr
ON
	app.PatientID=pr.PatientID LEFT JOIN Medications med 
ON 
	pr.MedicationID = med.MedicationID
WHERE
	YEAR(GETDATE())-YEAR(App.AppointmentDate)=1

-- 10. List all possible specialty-medication combinations, 
--	regardless of whether a doctor of that specialty has prescribed that medication.

SELECT dr.Specialty,md.MedicationName FROM Doctors dr CROSS JOIN Medications md