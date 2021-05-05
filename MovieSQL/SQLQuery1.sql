use pubs
select * from authors

create table tblMovie
(id int identity(1,1)primary key,
name varchar(20),
duration float)


select * from tblMovie
insert into tblMovie(name,duration) values('Theri',100)
insert into tblMovie(name,duration) values('Maara',200)
insert into tblMovie(name,duration) values('Silence',300)
insert into tblMovie(name,duration) values('Narnia',400)
insert into tblMovie(name,duration) values('Terminator',500)