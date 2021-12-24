CREATE TABLE orm_benchmark_table
(
    Id                BIGINT not null,
    StringField1      nvarchar(255) not null,
    StringField2      nvarchar(255) not null,
    StringField3      nvarchar(255) not null,
    LongField1        BIGINT not null,
    LongField2        BIGINT not null,
    LongField3        BIGINT not null,
    DateField1        date not null,
    DateField2        date not null,
    DateField3        date not null
);


DELETE FROM orm_benchmark_table;

DECLARE @i int = 0

WHILE @i < 1000000
    BEGIN
        SET @i = @i + 1

        insert into orm_benchmark_table (
            Id,
            StringField1, StringField2, StringField3,
            LongField1, LongField2, LongField3,
            DateField1, DateField2, DateField3
        )
        select
            @i,
            'STRING_FIELD1 ' + CAST(@i as nvarchar(MAX)),
            'STRING_FIELD2 ' + CAST(@i as nvarchar(MAX)),
            'STRING_FIELD3 ' + CAST(@i as nvarchar(MAX)),
            RAND(),
            RAND(),
            RAND(),
            GETDATE(),
            GETDATE(),
            GETDATE()

    END
