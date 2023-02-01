
create database controladm

use controladm

create table loginvb (
cod char(1) primary key,
usuario varchar (50),
contraseña varchar (50),
modo varchar(20)
)

insert into loginvb values('1', 'admin', '123','admins')
insert into loginvb values('2', 'secretario', '456','secretari@')
insert into loginvb values('3', 'usuario', '789','user')

insert into loginvb values(1, 'adsf', '123asdf')

delete from loginvb where cod = 3

select *from loginvb

drop table loginvb
