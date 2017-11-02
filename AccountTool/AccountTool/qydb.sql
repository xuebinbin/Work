drop table IF EXISTS ssdinfo;
drop table IF EXISTS threeinfo;
drop table IF EXISTS wabaoinfo;
drop table IF EXISTS wabaoqdinfo;

--
-- Table structure for table realtimeinfo
--

CREATE TABLE ssdinfo (
  NAME varchar2(30) NOT NULL,
  CYCLEDAYS varchar2(30),
  JE int,
  DATE varchar2(200),
  SETTLEMENTDATE varchar2(300),
  BZ varchar2(200)
);

CREATE TABLE threeinfo (
  NAME varchar2(30) NOT NULL,
  STARTRATE float,
  CURRATE  float,
  JE int,
  DATE varchar2(200),
  BZ varchar2(200)
);

CREATE TABLE wabaoinfo (
  NAME varchar2(30) NOT NULL,
  CYCLEDAYS varchar2(30),
  JE int,
  STARTDATE varchar2(200),
  BZ varchar2(200)
);

CREATE TABLE wabaoqdinfo (
  FIXINCOME   float,
  FLOATINGINCOM  float,
  CURRATE    float,
  BZ varchar2(200)
);

