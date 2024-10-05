create table [dbo].[Product](
	[Id] int not null primary key identity,
	[Name] nvarchar(20) not null
)
go

insert into [dbo].[Product]([Name]) values ('�����'),('����'),('�����'), ('�����')
go

create table [dbo].[Category](
	[Id] int not null primary key identity,
	[Name] nvarchar(20) not null
)
go

insert into [dbo].[Category]([Name]) values ('�������'),('��� ����'),('��� �����'), ('�����')
go

create table [dbo].[ProductCategories](
	[ProductId] int not null foreign key references [Product]([Id]),
	[CategoryId] int not null foreign key references [Category]([Id])
		primary key ([ProductId], [CategoryId])
)
go

insert into [dbo].[ProductCategories]([ProductId], [CategoryId]) values (1, 2), (1, 4), (2, 1), (4, 2)
go

select [Product].[Name] as '��� ��������', [Category].[Name] as '��� ���������' from [Product]
left join [ProductCategories] on [ProductCategories].[ProductId] = [Product].Id
left join [Category] on [ProductCategories].[CategoryId] = [Category].[Id]