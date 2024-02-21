CREATE DATABASE CSDLNC
GO

USE CSDLNC
GO

CREATE TABLE SystemUser(
	UserID char(5) PRIMARY KEY,
	Username varchar(50),
	Password varchar(50),
	SysUserName nvarchar(50),
	SysUserGender nvarchar(10),
	LoaiTaiKhoan char(10)
)
GO

CREATE TABLE Admin(
	AdminID char(5) PRIMARY KEY,

	LoaiTaiKhoan AS 'admin' PERSISTED 
)
GO

CREATE TABLE Staff(
	StaffID char(5) PRIMARY KEY,

	LoaiTaiKhoan AS 'staff' PERSISTED
)
GO

CREATE TABLE Dentist(
	DentistID char(5) PRIMARY KEY,

	LoaiTaiKhoan AS 'dentist' PERSISTED
)
GO



CREATE TABLE Room(
	RoomID char(5) PRIMARY KEY,
	RoomName nvarchar(50)
)
GO

CREATE TABLE Appointment(
	AppointmentID char(5) PRIMARY KEY,
	AppointmentDate date,
	Status nvarchar(20),
	RoomID char(5),
	DentistID char(5)
)
GO

ALTER TABLE Appointment 
ADD PatientID char(5)
go

CREATE TABLE WorkingCalendar(
	WorkingCalendarID char(5) PRIMARY KEY,
	MonthBegin date,
	MonthEnd date,
	DentistID char(5)
)
GO

CREATE TABLE Cal_DayInMonth(
	DayInMonth int,
	WorkingCalendarID char(5),

	PRIMARY KEY(DayInMonth, WorkingCalendarID)
)
GO

CREATE TABLE Cal_DayInWeek(
	DayInWeek int,
	WorkingCalendarID char(5),

	PRIMARY KEY(DayInWeek, WorkingCalendarID)
)
GO

CREATE TABLE Cal_FreeDay(
	DayFree date,
	WorkingCalendarID char(5),

	PRIMARY KEY(DayFree, WorkingCalendarID)
)
GO


CREATE TABLE TreatmentPlan(
	TreatmentPlanID char(5) PRIMARY KEY,
	Status nvarchar(20),
	DentistID char(5), 
	PatientID char(5)
)
GO

ALTER TABLE TreatmentPlan
ADD CONSTRAINT DF_STATUS
DEFAULT N'Đang điều trị' FOR Status

CREATE TABLE Treatment(
	TreatmentID char(5) PRIMARY KEY,
	Description nvarchar(50),
	TreatmentName nvarchar(50),
	TreatmentFee float,
	CategoryID char(5)
)
GO

CREATE TABLE Treatment_TreatmentPlan(
	TreatingID char(5) PRIMARY KEY,
	TreatmentID char(5),
	TreatmentPlanID char(5),
	TreatingDate date,
	TreatingFee float,
	PaymentStatus nvarchar(20)
)
GO

ALTER TABLE Treatment_TreatmentPlan
ADD CONSTRAINT DF_STATUS_TT
DEFAULT N'Chưa thanh toán' FOR PaymentStatus

CREATE TABLE Treating_Tooth(
	TreatingID char(5),
	ToothID char(5),
	ToothSurfaceID char(5)

	PRIMARY KEY (TreatingID, ToothID, ToothSurfaceID)
)
GO

CREATE TABLE Treating_Medicine(
	TreatingID char(5),
	MedicineID char(5),
	Amount int

	PRIMARY KEY(TreatingID, MedicineID)
)
GO

CREATE TABLE TreatmentCategory(
	CategoryID char(5) PRIMARY KEY,
	CategoryName nvarchar(50)
)
GO

CREATE TABLE Medicine(
	MedicineID char(5) PRIMARY KEY,
	MedicineName nvarchar(50),
	MedicinePrice float,
	MedicineDescription nvarchar(50)
)
GO


CREATE TABLE PaymentRecord(
	PaymentID char(5) PRIMARY KEY,
	Total float,
	PaymentDate date,
	PaymentType nvarchar(50),
	MoneyPaid float,
	MoneyChange float,
	TreatingID char(5)
)
GO

CREATE TABLE PatientProfile(
	PatientID char(5) PRIMARY KEY,
	PatientName nvarchar(50),
	PatientGender nvarchar(20),
	PatientAddress nvarchar(50),
	PatientDOB date,
	PatientEmail varchar(50),
	PatientPhoneNum char(10),
	TotalBill float,
	TotalPayment float,
	TeethDescription nvarchar(100),
	Note nvarchar(100)
)
GO

CREATE TABLE Tooth(
	ToothID char(5) PRIMARY KEY,
	ToothName nvarchar(50),
)
GO

CREATE TABLE ToothSurface(
	ToothSurfaceID char(5) PRIMARY KEY,
	ToothSurfaceName nvarchar(50),
	ToothSurfaceDescription nvarchar(50)
)
GO

-- RANG BUOC TOAN VEN----
USE CSDLNC
-------KHOA NGOAI--------
ALTER TABLE Admin ADD
	CONSTRAINT FK_ADMIN_SYSUSER FOREIGN KEY(AdminID) REFERENCES SystemUser(UserID)
ALTER TABLE Staff ADD
	CONSTRAINT FK_STAFF_SYSUSER FOREIGN KEY(StaffID) REFERENCES SystemUser(UserID)
ALTER TABLE Dentist ADD
	CONSTRAINT FK_DENTIST_SYSUSER FOREIGN KEY(DentistID) REFERENCES SystemUser(UserID)
ALTER TABLE Appointment ADD
	CONSTRAINT FK_APPOINT_ROOM FOREIGN KEY(RoomID) REFERENCES Room(RoomID),
	CONSTRAINT FK_APPOINT_DENTIS FOREIGN KEY(DentistID) REFERENCES Dentist(DentistID)

ALTER TABLE Appointment ADD
	CONSTRAINT FK_APPOINT_PATIENT FOREIGN KEY(PatientID) REFERENCES PatientProfile(PatientID)

ALTER TABLE WorkingCalendar ADD
	CONSTRAINT FK_CAL_DENTIST FOREIGN KEY(DentistID) REFERENCES Dentist(DentistID)
ALTER TABLE Cal_DayInMonth ADD
	CONSTRAINT FK_CALMONTH_CAL FOREIGN KEY(WorkingCalendarID) REFERENCES WorkingCalendar(WorkingCalendarID)
ALTER TABLE Cal_DayInWeek ADD
	CONSTRAINT FK_CALWEEK_CAL FOREIGN KEY(WorkingCalendarID) REFERENCES WorkingCalendar(WorkingCalendarID)
ALTER TABLE Cal_FreeDay ADD
	CONSTRAINT FK_CALFREE_CAL FOREIGN KEY(WorkingCalendarID) REFERENCES WorkingCalendar(WorkingCalendarID)
ALTER TABLE TreatmentPlan ADD
	CONSTRAINT FK_TREATPLAN_DENTIST FOREIGN KEY(DentistID) REFERENCES Dentist(DentistID),
	CONSTRAINT FK_TREATPLAN_PATIENT FOREIGN KEY(PatientID) REFERENCES PatientProfile(PatientID)
ALTER TABLE Treatment ADD
	CONSTRAINT FK_TREAT_CATE FOREIGN KEY(CategoryID) REFERENCES TreatmentCategory(CategoryID)
ALTER TABLE Treatment_TreatmentPlan ADD
	CONSTRAINT FK_TREATING_TREAT FOREIGN KEY(TreatmentID) REFERENCES Treatment(TreatmentID),
	CONSTRAINT FK_TREATING_TREATPLAN FOREIGN KEY(TreatmentPlanID) REFERENCES TreatmentPlan(TreatmentPlanID)
ALTER TABLE Treating_Tooth ADD
	CONSTRAINT FK_TREATTOOTH_TREATING FOREIGN KEY(TreatingID) REFERENCES Treatment_TreatmentPlan(TreatingID),
	CONSTRAINT FK_TREATTOOTH_TOOTH FOREIGN KEY(ToothID) REFERENCES Tooth(ToothID),
	CONSTRAINT FK_TREATTOOTH_SURFACE FOREIGN KEY(ToothSurfaceID) REFERENCES ToothSurface(ToothSurfaceID)
ALTER TABLE Treating_Medicine ADD
	CONSTRAINT FK_TREATMEDICINE_TREATING FOREIGN KEY(TreatingID) REFERENCES Treatment_TreatmentPlan(TreatingID),
	CONSTRAINT FK_TREATMEDICINE_MEDICINE FOREIGN KEY(MedicineID) REFERENCES Medicine(MedicineID)
ALTER TABLE PaymentRecord ADD
	CONSTRAINT FK_PAYMENT_TREATING FOREIGN KEY(TreatingID) REFERENCES Treatment_TreatmentPlan(TreatingID)
GO

------DU LIEU
ALTER TABLE SystemUser ADD 
	CONSTRAINT CK_LOAI_TK CHECK (LoaiTaiKhoan IN('admin', 'staff', 'dentist'))
ALTER TABLE Cal_DayInWeek ADD
	CONSTRAINT CK_DAY_WEEK CHECK (DayInWeek >= 2 AND DayInWeek <= 8) --8: Sunday
ALTER TABLE TreatmentPlan ADD
	CONSTRAINT CK_PLAN_STATUS CHECK (Status IN (N'Đã hoàn thành', N'Đang điều trị'))
ALTER TABLE Treatment ADD 
	CONSTRAINT CK_TREATMENT_FEE CHECK (TreatmentFee >= 0)
ALTER TABLE Treatment_TreatmentPlan ADD 
	CONSTRAINT CK_TREATING_FEE CHECK (TreatingFee >= 0),
	CONSTRAINT CK_TREATING_PAYMENT CHECK (PaymentStatus IN (N'Đã thanh toán', N'Chưa thanh toán'))
ALTER TABLE Treating_Medicine ADD
	CONSTRAINT CK_TREATMEDICINE_AMOUNT CHECK (Amount > 0)
ALTER TABLE Medicine ADD
	CONSTRAINT CK_MEDICINE_PRICE CHECK (MedicinePrice > 0)
ALTER TABLE PaymentRecord ADD
	CONSTRAINT CK_PAYMENT_TOTAL CHECK (Total > 0),
	CONSTRAINT CK_PAYMENT_PAID CHECK (MoneyPaid > 0),
	CONSTRAINT CK_PAYMENT_CHANGE CHECK (MoneyChange > 0)


