create database checks

use checks

drop table if exists checks
drop table if exists bottom
drop table if exists nalog
drop table if exists fuel

create table fuel
(
fuel_id int primary key identity(1,1),
fuel_name nvarchar(40),
fuel_price money
)

create table nalog
(
nalog_id int primary key identity(1,1),
nalog_name nvarchar(10),
nalog_amount nvarchar(3)
)

create table bottom
(
bottom_id int primary key identity(1,1),
bottom_name nvarchar(20)
)

create table checks
(
checks_id int primary key identity(1,1),
checks_company nvarchar(80),
checks_place nvarchar(80),
checks_oblast nvarchar(80),
checks_street nvarchar(160),
checks_FH nvarchar(10),
checks_ZH nvarchar(12),
checks_IA nvarchar(8),
checks_PN nvarchar(12),
checks_number int,
checks_cashier nvarchar(60),
checks_11 nvarchar(4),
checks_12 nvarchar(5),
checks_fuel int foreign key references fuel(fuel_id),
checks_litre float,
checks_nalog int foreign key references nalog(nalog_id),
checks_date datetime,
checks_bottom int foreign key references bottom(bottom_id)
)

insert into fuel(fuel_name, fuel_price) values
('2710194300#ÄÈÇÏÀËÈÂÎ EH590','27.90'),
('1014453340#ÄÈÇÏÀËÈÂÎ ÌÍ660','20.93'),
('4032216760#ÄÈÇÏÀËÈÂÎ ÀÌ540','19.50')

insert into nalog(nalog_name, nalog_amount) values
('À', 20),
('Á', 30),
('Â', 40)

insert into bottom(bottom_name) values
('ğåçîíàíñ'),
('ïğîãğåñ'),
('ïğîâàíñ')

insert into checks(checks_company, checks_place, checks_oblast, checks_street, checks_FH, checks_ZH, checks_IA, checks_PN, checks_number, checks_cashier, checks_11, checks_12, checks_fuel, checks_litre, checks_nalog, checks_date, checks_bottom) values
('ÒÎÂ "ÀÃĞÎÏÅÒĞÎÒĞÅÉÄ"','ÀÂÒÎÇÀÏĞÀÂÎ×ÍÀ ÑÒÀÍÖ²ß ÒÈÒÎÂÀ','ÄÍ²ÏĞÎÏÅÒĞÎÂÑÜÊÀ ÎÁËÀÑÒÜ','Ì. ÂÅĞÕÍÜÎÄÍ²ÏĞÎÂÑÜÊ. ÂÓË. ÒÈÒÎÂÀ. 29À', '3000784835', '3Â1991040644','38517444','385174426595', 44951, '1', '8120', '01-01', 1, 10.75, 1, '12/07/21 08:07', 1)

SELECT COUNT(1) AS Expr1
FROM     checks
WHERE  (checks_bottom = @Original_bottom_id)

SELECT COUNT(1) AS Expr1
FROM     checks
WHERE  (checks_nalog = @Original_nalog_id)

SELECT COUNT(1) AS Expr1
FROM     checks
WHERE  (checks_fuel = @Original_fuel_id)

truncate table checks
truncate table fuel
select* from checks
select* from fuel
select* from bottom
select* from nalog