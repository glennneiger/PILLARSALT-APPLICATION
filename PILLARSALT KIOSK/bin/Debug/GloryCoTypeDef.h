/******************************************************************************

         Copyright (C) 2010 Glory Ltd. All rights reserved.

*******************************************************************************/

#ifndef	__GLORY_LTD_HEADER_TypeDef_
#define	__GLORY_LTD_HEADER_TypeDef_


#ifdef	WIN32
#pragma pack(push,1)
#endif

#ifdef __cplusplus
extern "C" {
#endif

#define GLY_RBU_OFFSET			0x100000
#define GLY_RBG_ROUTING_OFFSET	0x105000
#define GLY_PD61_OFFSET			0x110000
#define GLY_PD600_OFFSET		0x120000
#define GLY_RZ100_OFFSET		0x130000
#define GLY_RZ50_OFFSET			0x140000
#define GLY_RBW10_OFFSET		0x150000
#define GLY_RCW8_OFFSET			0x160000
#define GLY_RBGX3_OFFSET		0x170000
#define GLY_RCN50_OFFSET		0x180000
#define GLY_UW_OFFSET			0x190000
#define GLY_RBG100_OFFSET		0x1A0000
#define GLY_DE_OFFSET			0x1B0000
#define GLY_UWWINCE_OFFSET		0x1B5000
#define GLY_MESSAGE_EX_OFFSET	0x1C0000
#define GLY_RB500_OFFSET		0x200000
#define GLY_SDR100_OFFSET		0x205000
#define GLY_RBG200_OFFSET		0x210000
#define GLY_RBW100_OFFSET		0x220000
#define GLY_RCW100_OFFSET		0x230000
#define GLY_USF_OFFSET			0x240000
#define GLY_JAVA_IF_OFFSET		0x250000
#define GLY_SOAP_SERVICE_OFFSET	0x260000
#define GLY_SDRXRBWX_OFFSET		0x270000
#define GLY_SDRXRCWX_OFFSET		0x280000

typedef int GLYHANDLE;
typedef int GLYREQUESTID;
typedef GLYREQUESTID* LPGLYREQUESTID;

#define GLY_JPY	('J'+('P'<<8)+('Y'<<16))
#define GLY_USD	('U'+('S'<<8)+('D'<<16))
#define GLY_CAD	('C'+('A'<<8)+('D'<<16))
#define GLY_EUR	('E'+('U'<<8)+('R'<<16))
#define GLY_CNY	('C'+('N'<<8)+('Y'<<16))
#define GLY_KRW	('K'+('R'<<8)+('W'<<16))

#define GLY_SUCCESS           0
#define GLY_COMPLETE_MESSAGE      (1)
#define GLY_CANCELED              (2)
#define GLY_DEVICE_SPECIFIC_EVENT (3)
#define GLY_DEVICE_SPECIFIC_EVENT_BY_STRING	(4)
#define GLY_HANDLE_CLOSED         (5)
#define GLY_STATUS_OFFSET	(2000)
#define GLY_STATUS_CHANGE       (2001)
#define GLY_EMPTY               (2002)
#define GLY_EXIST               (2003)
#define GLY_FULL                (2004)
#define GLY_ERROR               (2005)
#define GLY_STATUS_IDLE         (2006)
#define GLY_STATUS_USING_OWN    (2007)
#define GLY_STATUS_BUSY         (2008)
#define GLY_STATUS_ERROR        (2009)
#define GLY_STATUS_ERROR_COMMUNICATION   (2010)
#define GLY_DEPOSIT_COUNT_CHANGE         (2011)
#define GLY_REPLENISH_COUNT_CHANGE       (2012)
#define GLY_NUMBER_COUNTING_COUNT_CHANGE (2013)
#define GLY_STATUS_DLL_INITIALIZE_BUSY   (2015)
#define GLY_HIGH                 (2017)
#define GLY_STOP                 (2018)
#define GLY_MISSING              (2020)
#define GLY_SHORTAGE			 (2021)
#define GLY_INTERMEDIATE_COLLECT_COUNT_CHANGE	(2025)
#define GLY_CLOSED               (2030)
#define GLY_OPENED               (2031)
#define GLY_VERIFY_COUNT_CHANGE  (2016)
#define GLY_NA					 (2023)
#define GLY_REFILL_COUNT_CHANGE  (2024)
#define GLY_COLLECT_COUNT_CHANGE (2032)
#define GLY_LOW                  (2014)
#define GLY_FEED_FAILED          (2033)
#define GLY_CLEAR_REQ_VERIFY     (2034)
#define GLY_WAIT_FOR_REMOVING    (3001)
#define GLY_REMOVED              (3002)
#define GLY_POWER_OFF_ON_REQUEST (3003)
#define GLY_PUSH_INUSE_KEY       (3004)
#define GLY_ISSUE_RESET_COMMAND  (3006)
#define GLY_ENTRANCE             (4001)
#define GLY_EXIT                 (4002)
#define GLY_ESCROW               (4003)
#define GLY_STACKER1             (4004)
#define GLY_STACKER2             (4005)
#define GLY_STACKER3             (4006)
#define GLY_STACKER4             (4007)
#define GLY_STACKER5             (4008)
#define GLY_STACKER6             (4009)
#define GLY_RJB                  (4010)
#define GLY_CASSETTE1            (4025)
#define GLY_CASSETTE2            (4026)
#define GLY_CASSETTE3            (4027)
#define GLY_CASSETTE4            (4028)
#define GLY_CASSETTE5            (4029)
#define GLY_CASSETTE6            (4030)
#define GLY_DOWNLOAD_PROGRESS    (4141)
#define GLY_LOGREAD_PROGRESS     (4142)
#define GLY_SAFE_DOOR            (4155)
#define GLY_CASSETTE             (4166)
#define GLY_STACKER7             (4177)
#define GLY_STACKER8             (4178)
#define GLY_EXIT_RJ              (4201)
#define GLY_CASSETTE7            (4202)
#define GLY_CASSETTE8            (4203)
#define GLY_CATEGORY_1           (4211)
#define GLY_CATEGORY_2           (4212)
#define GLY_CATEGORY_3           (4213)
#define GLY_CATEGORY_4A          (4214)
#define GLY_CATEGORY_4B          (4215)
#define GET_IGNORE_STATE_FOR_OCX (5010)
#define GLY_OVER                 (5011)

#define GLY_CPS1_DISPENSE1 (7001)
#define GLY_CPS2_DISPENSE1 (7002)
#define GLY_CPS3_DISPENSE1 (7003)
#define GLY_CPS4_DISPENSE1 (7004)
#define GLY_CPS5_DISPENSE1 (7005)
#define GLY_CPS6_DISPENSE1 (7006)
#define GLY_CPS1_DISPENSE2 (7007)
#define GLY_CPS2_DISPENSE2 (7008)
#define GLY_CPS3_DISPENSE2 (7009)
#define GLY_CPS4_DISPENSE2 (7010)
#define GLY_CPS5_DISPENSE2 (7011)
#define GLY_CPS6_DISPENSE2 (7012)
#define GLY_CPS1_COUNTER   (7013)
#define GLY_CPS2_COUNTER   (7014)
#define GLY_CPS3_COUNTER   (7015)
#define GLY_CPS4_COUNTER   (7016)
#define GLY_CPS5_COUNTER   (7017)
#define GLY_CPS6_COUNTER   (7018)
#define GLY_CPS7_COUNTER   (7019)
#define GLY_CPS8_COUNTER   (7020)
#define GLY_CONTAINER_C4A_COUNTER (7021)
#define GLY_DEPOSIT_COUNT_MONITOR (7022)
#define GLY_CONTAINER_C1_COUNTER  (7023)
#define GLY_CONTAINER_C2_COUNTER  (7024)
#define GLY_CONTAINER_C3_COUNTER  (7025)
#define GLY_CPS1_C3_COUNTER       (7026)
#define GLY_CPS2_C3_COUNTER       (7027)
#define GLY_CPS3_C3_COUNTER       (7028)
#define GLY_CPS4_C3_COUNTER       (7029)
#define GLY_CPS6_C3_COUNTER       (7030)
#define GLY_CPS8_C3_COUNTER       (7031)
#define GLY_CAPTUREBIN_COUNTER    (7032)
#define GLY_CURRENCY_DEVICE       (7033)
#define GLY_NUM_DEVICE_EXIT       (7034)
#define GLY_MAX_DISPENSE_CNT      (7035)
#define GLY_CONTAINER_C4B_COUNTER (7036)
#define GLY_STATUS_COUNTING       (7037)
#define GLY_COLLECTION_BOX        (7038)
#define GLY_COLLECT_BOX_INSERTED  (7039)
#define GLY_REJECT_BOX		      (7040)
#define BillsToCaptureBin         (7041)
#define RZ_GetSerialNumber        (7042)
#define RZ_GetCstSerialNumber     (7043)
#define RZ_SetSerialNumber        (7044)
#define RZ_SetCstSerialNumber     (7045)
#define DirectDispense            (7046)
#define RejectDataRead            (7047)
#define NoteDataRead              (7048)
#define ModifyMessage             (7049)
#define WriteInformation          (7050)
#define ReadInformation           (7051)
#define GetCountNumber            (7052)
#define GLY_CAP_CANCEL_DEPOSIT    (7053)
#define GLY_CAP_PAUSE_DEPOSIT     (7054)
#define GLY_CAP_COMPARE_FIRM      (7055)
#define GLY_CAP_UPDATE_FIRM       (7056)
#define GLY_CAP_LOG_READ          (7057)
#define GLY_CAP_LOG_CLEAR         (7058)
#define GLY_CAP_DEPOSIT           (7059)
#define GLY_CAP_DESCREPANCY       (7060)
#define GLY_P_FIRMWARE_UNKNOWN    (7061)
#define GLY_P_FIRMWARE_SAME       (7062)
#define GLY_P_FIRMWARE_NEWER      (7063)
#define GLY_P_FIRMWARE_OLDER      (7064)
#define GLY_P_FIRMWARE_DIFFERENT  (7065)
#define GLY_CHECK_COUNTER         (7066)
#define DepositToCollection       (7067)
#define GLY_RBG_NOTE_DATA_INFO    (7068)
#define GLY_EXPOSED_FUND_COUNTER  (7069)

#define GLY_INDEFINITE_WAIT         (-1)

#define GLY_ERROR_SYSTEM_ERROR       (-1)
#define GLY_ERROR_PORT_OPEN_FAIL     (-2)
#define GLY_ERROR_PORT_CONFIG_ERROR  (-3)
#define GLY_ERROR_DEVICE_NOT_FOUND   (-4)
#define GLY_ERROR_PORT_NOT_FOUND     (-5)
#define GLY_ERROR_TCP_HOST_NOT_FOUND (-6)
#define GLY_ERROR_INVALID_HANDLE       (-7)
#define GLY_ERROR_INVALID_MESSAGE_CODE (-8)
#define GLY_ERROR_USER_WINDOW_MESSAGE_NOT_SET (-9)
#define GLY_ERROR_NOT_SUPPORTED_FUNCTION   (-10)
#define GLY_ERROR_INVALID_ID               (-11)
#define GLY_ERROR_NOT_SUPPORTED_CURRENCYID (-12)
#define GLY_ERROR_UDP_HOST_NOT_FOUND       (-13)
#define GLY_ERROR_ID_NOT_FOUND			   (-14)
#define GLY_ERROR_ALREADY_OPEN             (-16)
#define GLY_ERROR_DLL_NOT_FOUND            (-18)
#define GLY_ERROR_DEVICE_CONFIG_ERROR      (-19)
#define GLY_ERROR_FILE_NOT_FOUND           (-20)
#define GLY_ERROR_ELEMENT_NOT_FOUND        (-21)
#define GLY_ERROR_FILE_FORMAT              (-22)
#define GLY_ERROR_DL_FILE_SUM_CHECK_ERROR  (-23)
#define GLY_ERROR_DL_NEED_AGAIN            (-24)
#define GLY_ERROR_LOGICAL_NAME_NOT_DEFINED (-25)
#define GLY_ERROR_CONFIG_FILE_NOT_FOUND    (-26)
#define GLY_ERROR_INVALID_DLL    (-27)
#define GLY_ERROR_SEQUENCE       (-101)
#define GLY_ERROR_COMMUNICATION  (-102)
#define GLY_ERROR_BUSY           (-103)
#define GLY_ERROR_MECHA          (-104)
#define GLY_ERROR_OPERATION      (-105)
#define GLY_ERROR_PARAMETER      (-106)
#define GLY_ERROR_INVALID_PARAMETER	(-107)
#define	GLY_ERROR_MONEY_NOT_MATCHED	(-108)
#define GLY_ERROR_NOT_LOCKED     (-109)
#define GLY_ERROR_TIMEOUT        (-110)
#define GLY_ERROR_COM_PORT_IS_OCCUPIED	(-111)
#define GLY_ERROR_SHORTAGE       (-113)


#define GLY_ERROR_COMMUNICATION_OFFSET	(-1000)
#define GLY_ERROR_COMMUNICATION_TYPED_401	(GLY_ERROR_COMMUNICATION_OFFSET-1)
#define GLY_ERROR_COMMUNICATION_TYPED_402	(GLY_ERROR_COMMUNICATION_OFFSET-2)
#define GLY_ERROR_COMMUNICATION_TYPED_403	(GLY_ERROR_COMMUNICATION_OFFSET-3)
#define GLY_ERROR_COMMUNICATION_TYPED_404	(GLY_ERROR_COMMUNICATION_OFFSET-4)
#define GLY_ERROR_COMMUNICATION_TYPED_405	(GLY_ERROR_COMMUNICATION_OFFSET-5)
#define GLY_ERROR_COMMUNICATION_TYPED_406	(GLY_ERROR_COMMUNICATION_OFFSET-6)
#define GLY_ERROR_COMMUNICATION_TYPED_407	(GLY_ERROR_COMMUNICATION_OFFSET-7)
#define GLY_ERROR_COMMUNICATION_TYPED_408	(GLY_ERROR_COMMUNICATION_OFFSET-8)
#define GLY_ERROR_COMMUNICATION_TYPED_409	(GLY_ERROR_COMMUNICATION_OFFSET-9)
#define GLY_ERROR_COMMUNICATION_TYPED_410	(GLY_ERROR_COMMUNICATION_OFFSET-10)
#define GLY_ERROR_COMMUNICATION_TYPED_411	(GLY_ERROR_COMMUNICATION_OFFSET-11)
#define GLY_ERROR_COMMUNICATION_TYPED_412	(GLY_ERROR_COMMUNICATION_OFFSET-12)
#define GLY_ERROR_COMMUNICATION_TYPED_413	(GLY_ERROR_COMMUNICATION_OFFSET-13)
#define GLY_ERROR_COMMUNICATION_TYPED_414	(GLY_ERROR_COMMUNICATION_OFFSET-14)

#define GLY_ERROR_BILL_COUNTS (GLY_RBU_OFFSET+22)

typedef struct _GLYPARAM {
    GLYHANDLE    Handle;
    unsigned int dwErrorCode;
    unsigned int dwMessageID;
    GLYREQUESTID dwRequestID;
    int   ulSize;
    void* lpBuffer;
    const char* szParamName;
    int ApiID;
} GLYPARAM, *LPGLYPARAM;

typedef void (*GLYCALLBACK)(GLYPARAM* p);

typedef struct _GLYVALUEEXP {
    int Factor;
    int Exp;
} GLYVALUEEXP, *LPGLYVALUEEXP;

typedef struct _GLYSIGNATURE {
    char* SerialNumber;
    char* SerialNumberAttrib;
    int   DataSize;
    unsigned char* Data;
    void* misc;
} GLYSIGNATURE, *LPGLYSIGNATURE;

typedef struct _GLYCURRENCY {
    unsigned int ulValue;
    unsigned int ulCounts;
    char         cCurrencyID[4];
    int          Rev;
    GLYVALUEEXP  ValueExp;
    int          Category;
    GLYSIGNATURE** ppSignature;
    void* misc;
} GLYCURRENCY, *LPGLYCURRENCY;


#define getGLY_CurrencyID(x)	((*(ULONG*)x)&0x00ffffff)
#define setGLY_CurrencyID(x,y)	((*(ULONG*)x)=y)

typedef struct _GLYDENOMINATION {
    unsigned int  ulArraySize;
    LPGLYCURRENCY lpCurrencies;
} GLYDENOMINATION, *LPGLYDENOMINATION;

typedef struct _GLYCOUNTER {
    unsigned int    dwID;
    unsigned int    dwStatus;
    GLYDENOMINATION Denomination;
    void* misc;
} GLYCOUNTER, *LPGLYCOUNTER;

typedef struct _GLYCOUNTERS {
    unsigned int ulArraySize;
    LPGLYCOUNTER lpCounters;
} GLYCOUNTERS, *LPGLYCOUNTERS;

typedef struct _GLYCOMMONCURRENCY {
    unsigned int dwStatus;
    GLYCURRENCY  Currency;
} GLYCOMMONCURRENCY, *LPGLYCOMMONCURRENCY;

typedef struct _GLYCOMMONCOUNTER {
    unsigned int        ulArraySize;
    LPGLYCOMMONCURRENCY lpCommonCurrency;
    void* misc;
} GLYCOMMONCOUNTER, *LPGLYCOMMONCOUNTER;

typedef struct _GLYCOMMONCOUNTERS {
    LPGLYCOMMONCOUNTER lpDepositCounter;
    LPGLYCOMMONCOUNTER lpDispenseCounter;
    LPGLYCOMMONCOUNTER lpBalanceCounter;
} GLYCOMMONCOUNTERS, *LPGLYCOMMONCOUNTERS;

typedef struct _GLYSTRPARE {
    const char* ModuleName;
    const char* Version;
} GLYSTRPARE, *LPGLYSTRPARE;

typedef struct _GLYMODULEVERSION {
    int          ulAllaySize;
    LPGLYSTRPARE Ver;
} GLYMODULEVERSION, *LPGLYMODULEVERSION;

typedef struct _GLYPROGRESS {
    unsigned int dwTotalSize;
    unsigned int dwSentSize;
} GLYPROGRESS, *LPGLYPROGRESS;

typedef struct _GLYPROPERTY {
    const char*  szPropertyType;
    unsigned int dwPropertyVersion;
    void* pProperty;
} GLYPROPERTY, *LPGLYPROPERTY;

typedef struct _GLYOPERATIONMODE {
    const char*  szOperationName;
    unsigned int dwModeVersion;
    void* pMode;
} GLYOPERATIONMODE, *LPGLYOPERATIONMODE;

typedef struct _GLYIDANDSTRING
{
	int ID;
	const char* szString;
}GLYIDANDSTRING, *LPGLYIDANDSTRING;

typedef struct _GLYIDANDSTRINGTABLE
{
	int ArraySize;
	GLYIDANDSTRING* pTable;
}GLYIDANDSTRINGTABLE, *LPGLYIDANDSTRINGTABLE;

typedef struct _GLYDEVICESPECIFICCOMMAND {
	unsigned int	dwCommand;
	unsigned int	dwLength;
	unsigned char	pbyParam[1];
} GLYDEVICESPECIFICCOMMAND, *LPGLYDEVICESPECIFICCOMMAND;

typedef struct _GLYDEVICESPECIFICEVENT {
	unsigned int dwEvent;
	unsigned int dwLength;
	unsigned char  pbyParam[1];
} GLYDEVICESPECIFICEVENT, *LPGLYDEVICESPECIFICEVENT;

typedef void (*LOGMESSAGENOTIFIER)(char* msg, void* a);

typedef struct _GLYDEVICEPROPERTY
{
	const char* szDeviceType;
	unsigned int dwPropertyVersion;
	void* pProperty;
} GLYDEVICEPROPERTY, *LPGLYDEVICEPROPERTY;

typedef struct _GLYCSTPROPERTY
{
	int NearEmpty;
	int NearFull;
	int Max;
} GLYCSTPROPERTY, *LPGLYCSTPROPERTY;

typedef struct _GLYDATA {
	unsigned char bCategory;
	unsigned char bDirection;
	unsigned char bNationCode;
	unsigned char bDenomiCode;
	unsigned char bRjCode;
	unsigned char bFitAut;
	unsigned char bReserve[2];
} GLYDATA, *LPGLYDATA;

typedef struct _GLYREJECT {
	unsigned int ulArraySize;
	GLYDATA* lpData;
} GLYREJECT, *LPGLYREJECT;

typedef struct _GLYTERMINALINFO {
	unsigned int ulRegistrationNo;
	unsigned char  bStationInfo1[8];
	unsigned char  bStationInfo2[8];
	unsigned char  bStationInfo3[8];
	unsigned char  bStationInfo4[8];
	unsigned char  bStationInfo5[8];
} GLYTERMINALINFO, *LPGLYTERMINALINFO;

typedef struct _GLYMEMWRITE {
	unsigned char bData[4];
	unsigned int ulSize;
	unsigned char* lpbData;
} GLYMEMWRITE, *LPGLYMEMWRITE;

typedef struct _GLYMESSAGE {
	unsigned int ulMessageNo;
	unsigned int ulSize;
	unsigned char* lpbMessageData;
} GLYMESSAGE, *LPGLYMESSAGE;

typedef struct _GLYCOUNTFORECBA6 {
  unsigned int	ulValue;
  char	cCurrencyID[4];
  int	Rev;
  unsigned int	ulCountsC2;
  unsigned int	ulCountsC3;
  unsigned int	ulCountsC4;
} GLYCOUNTFORECBA6, *LPGLYCOUNTFORECBA6;

typedef struct _GLYCOUNTSFORECBA6 {
  unsigned int		ulArraySize;
  LPGLYCOUNTFORECBA6	lpCountForECB;
} GLYCOUNTSFORECBA6, *LPGLYCOUNTSFORECBA6;

typedef struct _GLYSIGNATUREFORECBA6 {
  unsigned int ulValue;
  char	cCurrencyID[4];
  int	Rev;
  unsigned int	ulCategory;
  unsigned char	bData[24];
} GLYSIGNATUREFORECBA6, *LPGLYSIGNATUREFORECBA6;

typedef struct _GLYSIGNATURESFORECBA6 {
  unsigned int		ulArraySize;
  LPGLYSIGNATUREFORECBA6	lpSignature;
} GLYSIGNATURESFORECBA6, *LPGLYSIGNATURESFORECBA6;

typedef struct _GLYCOUNTRESULT {
	GLYDENOMINATION C4;
	GLYDENOMINATION C3;
	GLYDENOMINATION C2;
	GLYDENOMINATION C1;
	GLYDENOMINATION C4B;
	GLYDENOMINATION C4A;
} GLYCOUNTRESULT, *LPGLYCOUNTRESULT;

typedef struct _GLYROLLBACKUNIT
{
	int Position;
	unsigned int ulCount;
} GLYROLLBACKUNIT, *LPGLYROLLBACKUNIT;

typedef struct _GLYROLLBACK
{
	unsigned int ulArraySize;
	LPGLYROLLBACKUNIT lpRollBackUnits;
} GLYROLLBACK, *LPGLYROLLBACK;

typedef struct _GLYERRORBILLCOUNTS {
	unsigned int	dwErrorCode;
	unsigned int	ulTotal;
	GLYDENOMINATION Denomination;
} GLYERRORBILLCOUNTS, *LPGLYERRORBILLCOUNTS;

#ifdef __cplusplus
}
#endif

#ifdef	WIN32
#pragma pack(pop)
#endif

#endif	// __GLORY_LTD_HEADER_TypeDef_
