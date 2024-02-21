USE CSDLNC;
GO
CREATE PROCEDURE sp_InsertSystemUser
	@userID CHAR(5),
    @username NVARCHAR(50),
    @password NVARCHAR(50),
    @fullname NVARCHAR(50),
    @gender NVARCHAR(10),
    @userType CHAR(10)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO SystemUser (UserID, Username, Password, SysUserName, SysUserGender, LoaiTaiKhoan)
    VALUES (@userID, @username, @password, @fullname, @gender, @userType);

END;
GO
CREATE PROCEDURE sp_UpdateSystemUser
    @userID CHAR(5),
    @fullname NVARCHAR(50),
    @gender NVARCHAR(50),  -- Assuming 'SysUserGender' is NVARCHAR(50) in SystemUser table
    @result NVARCHAR(50) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if the user exists
    IF EXISTS (SELECT 1 FROM SystemUser WHERE UserID = @userID)
    BEGIN
        -- Perform the update
        UPDATE SystemUser
        SET SysUserName = @fullname,
            SysUserGender = @gender
        WHERE UserID = @userID;

        SET @result = 'Update successful';
    END
    ELSE
    BEGIN
        -- User does not exist
        SET @result = 'User not found';
    END
END;
GO
CREATE PROCEDURE sp_InsertMedicine
    @MedicineID CHAR(5),
    @MedicineName NVARCHAR(50),
    @MedicinePrice FLOAT,
    @MedicineDescription NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Medicine (MedicineID, MedicineName, MedicinePrice, MedicineDescription)
    VALUES (@MedicineID, @MedicineName, @MedicinePrice, @MedicineDescription);
END;
GO
CREATE PROCEDURE sp_UpdateMedicine
    @MedicineID CHAR(5),
    @MedicineName NVARCHAR(50),
    @MedicinePrice FLOAT,
    @MedicineDescription NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if the medicine exists
    IF EXISTS (SELECT 1 FROM Medicine WHERE MedicineID = @MedicineID)
    BEGIN
        -- Perform the update
        UPDATE Medicine
        SET MedicineName = @MedicineName,
            MedicinePrice = @MedicinePrice,
            MedicineDescription = @MedicineDescription
        WHERE MedicineID = @MedicineID;

        SELECT 'Update successful' AS Result;
    END	
    ELSE
    BEGIN
        -- Medicine does not exist
        SELECT 'Medicine not found' AS Result;
    END
END;
GO
CREATE PROCEDURE sp_InsertPatientProfile
    @PatientID CHAR(5),
    @PatientName NVARCHAR(50),
    @PatientGender NVARCHAR(20),
    @PatientAddress NVARCHAR(50),
    @PatientDOB DATE,
    @PatientEmail VARCHAR(50),
    @PatientPhoneNum CHAR(10)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO PatientProfile (PatientID, PatientName, PatientGender, PatientAddress, PatientDOB, PatientEmail, PatientPhoneNum)
    VALUES (@PatientID, @PatientName, @PatientGender, @PatientAddress, @PatientDOB, @PatientEmail, @PatientPhoneNum);
END;
GO
CREATE PROCEDURE sp_UpdatePatientProfile
    @PatientID CHAR(5),
    @PatientName NVARCHAR(50),
    @PatientGender NVARCHAR(20),
    @PatientAddress NVARCHAR(50),
    @PatientDOB DATE,
    @PatientEmail VARCHAR(50),
    @PatientPhoneNum CHAR(10)
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if the patient exists
    IF EXISTS (SELECT 1 FROM PatientProfile WHERE PatientID = @PatientID)
    BEGIN
        -- Perform the update
        UPDATE PatientProfile
        SET PatientName = @PatientName,
            PatientGender = @PatientGender,
            PatientAddress = @PatientAddress,
            PatientDOB = @PatientDOB,
            PatientEmail = @PatientEmail,
            PatientPhoneNum = @PatientPhoneNum
        WHERE PatientID = @PatientID;

        SELECT 'Update successful' AS Result;
    END
    ELSE
    BEGIN
        -- Patient does not exist
        SELECT 'Patient not found' AS Result;
    END
END;
GO
CREATE PROCEDURE sp_UpdateProfileSystemUser
    @userID CHAR(5),
    @Username VARCHAR(50),
    @Password VARCHAR(50),
    @fullname NVARCHAR(50),
    @gender NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if the user exists
    IF EXISTS (SELECT 1 FROM SystemUser WHERE UserID = @userID)
    BEGIN
        -- Perform the update
        UPDATE SystemUser
        SET Username = @Username,
            Password = @Password,
            SysUserName = @fullname,
            SysUserGender = @gender
        WHERE UserID = @userID;

        SELECT 'Update successful' AS Result;
    END
    ELSE
    BEGIN
        -- User does not exist
        SELECT 'User not found' AS Result;
    END
END;
GO
CREATE PROCEDURE sp_UpdateAppointment
    @AppointmentID CHAR(5),
    @Status NVARCHAR(20),
    @RoomID CHAR(5),
    @DentistID CHAR(5),
    @PatientID CHAR(5)
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if the appointment exists
    IF EXISTS (SELECT 1 FROM Appointment WHERE AppointmentID = @AppointmentID)
    BEGIN
        -- Perform the update
        UPDATE Appointment
        SET Status = @Status,
            RoomID = @RoomID,
            DentistID = @DentistID,
            PatientID = @PatientID
        WHERE AppointmentID = @AppointmentID;

        SELECT 'Update successful' AS Result;
    END
    ELSE
    BEGIN
        -- Appointment does not exist
        SELECT 'Appointment not found' AS Result;
    END
END;
GO
CREATE PROCEDURE sp_GetTreatmentPlansByDentistAndDateRange
    @DentistID CHAR(5),
    @fromDate DATE,
    @toDate DATE
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM TreatmentPlan TP
    JOIN Treatment_TreatmentPlan TTP ON TP.TreatmentPlanID = TTP.TreatmentPlanID
    WHERE TP.DentistID = @DentistID
        AND @fromDate <= TTP.TreatingDate
        AND TTP.TreatingDate <= @toDate;
END;


