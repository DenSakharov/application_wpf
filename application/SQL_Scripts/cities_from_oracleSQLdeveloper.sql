--------------------------------------------------------
--  File created - �����������-�������-04-2024   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table CITYDICTIONARY
--------------------------------------------------------

  CREATE TABLE "MYUSER"."CITYDICTIONARY" 
   (	"ID" NUMBER(*,0), 
	"CITYNAME" VARCHAR2(255 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
REM INSERTING into MYUSER.CITYDICTIONARY
SET DEFINE OFF;
Insert into MYUSER.CITYDICTIONARY (ID,CITYNAME) values ('1','������');
Insert into MYUSER.CITYDICTIONARY (ID,CITYNAME) values ('2','�����-���������');
Insert into MYUSER.CITYDICTIONARY (ID,CITYNAME) values ('3','������ ��������');
Insert into MYUSER.CITYDICTIONARY (ID,CITYNAME) values ('4','������');
--------------------------------------------------------
--  DDL for Index SYS_C008319
--------------------------------------------------------

  CREATE UNIQUE INDEX "MYUSER"."SYS_C008319" ON "MYUSER"."CITYDICTIONARY" ("ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Trigger CITYDICTIONARY_BEFOREINSERT
--------------------------------------------------------

  CREATE OR REPLACE NONEDITIONABLE TRIGGER "MYUSER"."CITYDICTIONARY_BEFOREINSERT" 
BEFORE INSERT ON CityDictionary
FOR EACH ROW
BEGIN
    SELECT CityDictionary_Seq.NEXTVAL INTO :NEW.ID FROM dual;
END;
/
ALTER TRIGGER "MYUSER"."CITYDICTIONARY_BEFOREINSERT" ENABLE;
--------------------------------------------------------
--  Constraints for Table CITYDICTIONARY
--------------------------------------------------------

  ALTER TABLE "MYUSER"."CITYDICTIONARY" MODIFY ("CITYNAME" NOT NULL ENABLE);
  ALTER TABLE "MYUSER"."CITYDICTIONARY" ADD PRIMARY KEY ("ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;