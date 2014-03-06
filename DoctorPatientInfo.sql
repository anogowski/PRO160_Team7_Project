use MedicalSystem

Go

Insert Into Fields(Name)
Values 
('Anesthesiologists‎'),
('Cardiologists'),
('Coroners'),
('Dentists‎'),
('Dermatologists'),
('Diabetologists‎'),
('Endocrinologists‎'),
('Gastroenterologists‎'),
('General practitioners'),
('Gynaecologists'),
('Hematologists'),
('High-altitude medicine physicians‎'),
('Hygienists‎'),
('Immunologists'),
('Leprologists'),
('Military physicians'),
('Neurologists‎'),
('Neurosurgeons'),
('Obstetricians‎'),
('Oncologists‎'),
('Ophthalmologists‎'),
('Orthopaedists'),
('Paleopathologists‎'),
('Parasitologists‎'),
('Pathologists‎'),
('Pediatricians‎'),
('Podiatrists‎'),
('Psychiatrists‎'),
('Pulmonologists‎'),
('Radiologists'),
('Rheumatologists‎'),
('Serologists'),
('Surgeons'),
('Toxicologists'),
('Traumatologists'),
('Urologists'),
('Venereologists'),
('Virologists')

Go

Insert Into Administrator (username, psw)
Values
('admin','password'),
('Adam','im1337'),
('Ashtinh','Le')

Go

Insert Into Doctor(FID,UserName,psw,HomeAddress,PhoneNumber)
Values
(1,'Josh','ucantsuemeifurdead','SLC','8019876783'),
(10,'Rafik','password','Cairo','8054261337'),
(36,'Yi','imbetterthanyou','China','7298347299')

Go

Insert Into BloodType (TypeName)
Values
('O +'),
('O -'),
('A +'),
('A -'),
('B +'),
('B -'),
('AB +'),
('AB -')

Go

Insert Into Patient (Gender,DateOfBirth, DateOfDeath, BloodType_id, HomeAddress, PhoneNumber, Syptoms)
Values

(0, '12-01-1990', null, 1, '1 Main St', '1234567890', 'Fever, Headache'),
(0, '12-11-95', null, 1, '100 North', '1234567890', 'Headache, Fatiuge'),
(1, '01-01-00', null, 8, '321 Main St', '0987654321', 'Fever, Stomach Ache, Cramps')

Go

Insert Into Doc_Patient (DID, PID)
Values
(1,2),
(1,3),
(2,4)
Go
