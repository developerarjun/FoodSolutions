CREATE PROCEDURE getLoginAdmin(@username varchar(100),@password text) 
AS  
BEGIN  
    Select a.user_name,b.full_name from np_profile_admin  b INNER JOIN np_admin_login a 
	ON b._id = a.person_id_profile
	where a.user_name = @username and 
	a.password = @password and 
	b.is_active = 1 and
	a.is_active = 1;  
END  