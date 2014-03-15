go
create Database MedicalSystem
go

use MedicalSystem
create table BloodType
(
	BID int identity(1,1) primary key,
	TypeName nchar(10) default('A') not null, 
)

create table Medicine
(
	MID int identity(1,1) primary key,
	Name nchar(100) not null,
	Note text null
)

create table Prescription
(
	PRE_ID int identity(1,1) primary key, 
	DID int,
	PID int ,
	DateIssued datetime default(getdate()) not null,
	Note text null,
	Reactions text null
)

create table Prescription_Medicine
(
	PRE_ID int constraint fk_pre_id
    foreign key (PRE_ID)
    references Prescription(pre_id),
    
    MID int constraint fk_medicine
    foreign key (MID)
    references Medicine(MID),
)

create table Appointment
(
	AID int identity(1,1) primary key,
	AppointmentDate datetime default(getDate()),
)

create table Patient
(
	PID int identity(1,1) primary key,
	SSID char(20) not null,
	FirstName char(50) not null,
	LastName char(50)not null,
	Gender bit not null,
	Age int not null,
	DateOfBirth datetime default('1900-1-1'),
	DateOfDeath datetime default(null),
	BloodType_id int constraint fk_bloodTpe
    foreign key (BloodType_id)
    references BloodType(BID),
	CurrentHeight int not null,
	CurrentWeight float not null,
    HomeAddress nchar(100) null, 
    PhoneNumber nchar(15),
    Symptoms text, 
)

create table Fields
(
	FID int identity(1,1) primary key, 
	Name char(50) not null
)

create table Doctor
(
	DID int identity(1,1) primary key,
	FID int constraint fk_fid
	foreign key (FID) references Fields(FID),
	UserName char(20) not null,
	psw char(20) not null,
	HomeAddress nchar(100), 
	PhoneNumber nchar(15), 
)

create table DiseaseType
(
	DTID int identity(1,1) primary key, 
	Name char(50)
)

create table Disease
(
	DISID int identity(1,1) primary key, 
	Name char(50) not null,
	Disease_type int constraint fk_disease_type 
		foreign key (Disease_type) references DiseaseType(DTID)
)

create table Disease_Patient
(
	PID int constraint fk_patient_disease
	foreign key (PID) references Patient(PID),
	
	DISID int constraint fk_disid
	foreign key (PID) references Disease(DISID),
)

create table Doc_Patient_appointment
(
	PID int constraint fk_pid 
	foreign key (PID) references Patient(PID),
	DID int constraint fk_did 
	foreign key (DID) references Doctor(DID),
	AID int constraint fk_aid 
	foreign key (AID) references Appointment(AID),
)

create table Doc_Patient
(
	
	PID int constraint fk_patient_doc
	foreign key (PID) references Patient(PID) not null,
	DID int constraint fk_doc_patient
	foreign key (DID) references Doctor(DID) not null,
	primary key(PID, DID),
)

create table Administrator 
(
	ID int identity(1,1) primary key,
	username char(20)not null,
	psw char(20) not null
)

-- need to add fk between patient and prescription
alter table Prescription
	add constraint fk_prescription
		foreign key (PID)
		references  patient(PID)
alter table Prescription
	add constraint fk_issued_by
		foreign key (DID)
		references  Doctor(DID)
				
-- need to add fk between patient and appointmentalter table patient
--alter table Doc_Patient_appointment
--	add constraint fk_appointment_patient
--		foreign key (PID)
--		references  patient(PID)
----alter table Doc_Patient_appointment		
----	add constraint fk_appointment_doctor
----		foreign key (DID)
----		references  Doctor(DID)
----alter table Doc_Patient_appointment		
----	add constraint fk_appointment_appointment
----		foreign key (AID)
----		references  Appointment(AID)		