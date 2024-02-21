USE CSDLNC1


-- CÀI ĐẶT INDEX
-- Tìm kiếm thông tin của nha sĩ theo tên đăng nhập
CREATE NONCLUSTERED INDEX idx_username ON systemuser_index(username)

--  DROP INDEX idx_username ON systemuser_index
--1
SELECT* FROM systemuser
WHERE username  = 'sqqcpgrf' AND loaitaikhoan = 'dentist'	

--2
SELECT* FROM systemuser_index
WHERE username  = 'sqqcpgrf' AND loaitaikhoan = 'dentist'

-- Tìm kiếm trạng thái kế hoạch điều trị của bệnh nhân theo mã bệnh nhân
CREATE NONCLUSTERED INDEX idx_id ON TreatmentPlan_Index(patientid)

--DROP INDEX idx_id ON TreatmentPlan_index
--1
SELECT * FROM TreatmentPlan
WHERE patientid = 'PT10009874'

--2
SELECT * FROM TreatmentPlan_Index
WHERE patientid = 'PT10009874'



--Tìm kiếm các điều trị mà nha sĩ đã hoàn thành
CREATE NONCLUSTERED INDEX idx_den_id ON TreatmentPlan_Index(DentistID)
--1
SELECT * FROM TreatmentPlan
WHERE dentistID = 'US10000007' AND Status = N'Đã hoàn thành'

--2
SELECT * FROM TreatmentPlan_Index
WHERE dentistID = 'US10000007' AND Status = N'Đã hoàn thành'



-- Xem index được tạo
select * from sys.indexes where object_id = OBJECT_ID('systemuser_index')
SELECT * from sys.indexes where object_id = OBJECT_ID('TreatmentPlan_Index')



