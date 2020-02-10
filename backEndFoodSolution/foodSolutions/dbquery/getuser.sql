CREATE PROCEDURE ins_menu(@menuname varchar(100),@price float,@isavailable bit,@stock varchar(50)) 
AS  
BEGIN  
    INSERT into np_food_menu (
					_id,
					menu_name,
					price,
					is_available,
					entry_by,
					entry_date,
					quantity
	)values
	(
		select ISNULL(max(_id),0)+1 from np_food_menu,
		@menuname,
		@price,
		@isavailable,
		'Canteen Admin',
		getdate(),
		@stock
	)
END  