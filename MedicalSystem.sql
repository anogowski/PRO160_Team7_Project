
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

create table Perscription
(
	PERS_ID int identity(1,1) primary key, 
	DID int,
	PID int ,
	DateIssued datetime default(getdate()) not null,
	Note text null,
	Reactions text null
)

create table Perscription_Medicine
(
	PERS_ID int constraint fk_pers_id
    foreign key (PERS_ID)
    references Perscription(pers_id),
    
    MID int constraint fk_medicine
    foreign key (MID)
    references Medicine(MID),
)

create table Appointment
(
	AID int identity(1,1) primary key,
	DateIssued datetime default(getDate()),
)

create table Patient
(
	PID int identity(1,1) primary key,
	Gender bit not null,
	DateOfBirth datetime default('1900-1-1'),
	BloodType_id int constraint fk_bloodTpe
    foreign key (BloodType_id)
    references BloodType(BID),
    HomeAddress nchar(100) null, 
    PhoneNumber nchar(15),
    Syptoms text, 
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
	DEAID int identity(1,1) primary key, 
	Name char(50) not null,
	Disease_type int constraint fk_disease_type 
		foreign key (Disease_type) references DiseaseType(DTID)
)

create table Disease_Patient
(
	PID int constraint fk_patient_disease
	foreign key (PID) references Patient(PID),
	
	DEAID int constraint fk_deaid
	foreign key (PID) references Disease(DEAID),
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
	foreign key (PID) references Patient(PID),
	DID int constraint fk_doc_patient
	foreign key (DID) references Doctor(DID),
)
-- need to add fk between patient and perscription
alter table Perscription
	add constraint fk_perscription
		foreign key (PID)
		references  patient(PID)
alter table Perscription
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