USE CSDLNC
INSERT INTO SystemUser (UserID, Username, Password, SysUserName,SysUserGender,LoaiTaiKhoan)
VALUES 
('US101','admin','123','Dang Huy','Khac','admin'),
('US102','nhanvien','123','Phuong Lam','Nam','staff'),
('US103','nhasi','123','Phuc','Nam','dentist');

INSERT INTO Admin(AdminID)
VALUES 
('US101');
INSERT INTO Staff(StaffID)
VALUES 
('US102');
INSERT INTO Dentist(DentistID)
VALUES 
('US103');

INSERT INTO TreatmentCategory(CategoryID, CategoryName)
VALUES 
('C1001','Phan loai 1'),
('C1002','Phan loai 2');
INSERT INTO Treatment(TreatmentID, Description,TreatmentName,TreatmentFee,CategoryID)
VALUES 
('T1001','Description 1','Treatment name 1','20','C1001'),
('T1002','Description 2','Treatment name 2','30','C1002');


INSERT INTO Tooth(ToothID, ToothName)
VALUES 
('TTH11','rang cua'),
('TTH12','rang ham');

INSERT INTO ToothSurface(ToothSurfaceID, ToothSurfaceName,ToothSurfaceDescription)
VALUES 
('TTS11','Lingual','Mat trong'),
('TTS12','Facial','Mat ngoai');

INSERT INTO PatientProfile(PatientID, PatientName,PatientGender,PatientAddress,PatientDOB,PatientEmail,PatientPhoneNum,TotalBill,TotalPayment,TeethDescription,Note)
VALUES 
('PT101','long','Nam','157 Duong Ba Trac','2003-03-18','dangmanhphuc2003@gmail.com','0856377469',NULL,NULL,NULL,NULL);

INSERT INTO TreatmentPlan(TreatmentPlanID, Status,DentistID,PatientID)
VALUES 
('TP101',N'Đã hoàn thành','US103','PT101'),
('TP102',N'Đang điều trị','US103','PT101');

INSERT INTO Treatment_TreatmentPlan(TreatingID, TreatmentID,TreatmentPlanID,TreatingDate,TreatingFee,PaymentStatus)
VALUES 
('P1001','T1001','TP101','01/01/2023',NULL,N'Đã thanh toán'),
('P1002','T1002','TP102','01/02/2023',NULL,N'Chưa thanh toán');

INSERT INTO Treating_Tooth(TreatingID, ToothID,ToothSurfaceID)
VALUES 
('P1001','TTH11','TTS11'),
('P1001','TTH12','TTS12');

INSERT INTO Treating_Medicine(TreatingID, MedicineID,Amount)
VALUES 
('P1001','MC101',12),
('P1001','MC102',12);

INSERT INTO Medicine(MedicineID, MedicineName,MedicinePrice,MedicineDescription)
VALUES 
('MC101','Thuoc giam dau',22.2,'Thuoc ke don'),
('MC102','Thuoc khang sinh',33.3,'Thuoc ke don');

INSERT INTO PaymentRecord(PaymentID, Total,PaymentDate,PaymentType,MoneyPaid,MoneyChange,TreatingID)
VALUES 
('PM101',NULL,NULL,NULL,NULL,NULL,'P1001');

INSERT INTO Room(RoomID,RoomName)
VALUES 
('R1001','Phong 1'),
('R1002','Phong 2');

INSERT INTO Appointment(AppointmentID,AppointmentDate,Status,RoomID,DentistID,PatientID)
VALUES 
('AP101','12-29-2023',NULL,'R1001','US103','PT101');

INSERT INTO WorkingCalendar
VALUES(
	'CL100', '2023-01-01', '2024-01-01', 'US103'
)
--xong













