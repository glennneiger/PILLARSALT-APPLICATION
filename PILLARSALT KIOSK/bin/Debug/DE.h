/******************************************************************************

         Copyright (C) 2010 Glory Ltd. All rights reserved.

*******************************************************************************/

#ifndef __GLY_DE_header__
#define __GLY_DE_header__

#include "GloryCoLx2010.h"
#include "time.h"

#ifdef	WIN32
#pragma pack(push,1)
#endif

#ifdef __cplusplus
extern "C" {
#endif

#define GLY_DEPOSIT_MANUAL_NUM		7
#define GLY_DEPOSIT_OPERATORID_MAX	9                             // 末尾NULL
#define GLY_LOG_NUM_MAX				15
#define GLY_NOWAIT_STATUS_NUM_MAX	2
#define GLY_WAIT_STATUS_NUM_MAX		8
#define GLY_SERIAL_BUFFER_MAX		512
#define GLY_DE_MAX_SERIAL			999
#define	GLY_DE_AMOUNT_MAX			64	//2012.11.28 add Ver.0301 課題№00535 suzuki
#define	GLY_DE_LOCK_BASE_LEN		12	//2013.03.07 add Ver.0302 課題№00626 suzuki

#define GLY_DEPOSIT_ERROR					(GLY_DE_OFFSET + 1)	// 処理機がエラーを検知した時に通知する
#define GLY_DEPOSIT_COUNTRESULT				(GLY_DE_OFFSET + 2)	// 入金結果を通知する
#define GLY_DEPOSIT_MANUALCOUNT				(GLY_DE_OFFSET + 3)	// 現外入金結果を通知する
#define GLY_DEPOSIT_CLOSING					(GLY_DE_OFFSET + 4)	// 締め結果を通知する
#define GLY_DEPOSIT_COLLECT					(GLY_DE_OFFSET + 5)	// 回収結果を通知する
#define GLY_DEPOSIT_CASSETTECHANGE			(GLY_DE_OFFSET + 6)	// カセット交換結果を通知する
#define GLY_DEPOSIT_CLEARERROR				(GLY_DE_OFFSET + 7)	// 障害の解除結果を通知する
#define GLY_DEPOSIT_WITHOUTSTORE			(GLY_DE_OFFSET + 8)	// 入金結果を通知する(収納無し)

#define GLY_DE_DEVICESETTINGDATA			(GLY_DE_OFFSET + 9)	// 接続時の設定データを通知する
#define GLY_DE_DENOMINATIONDATA				(GLY_DE_OFFSET + 10)// 接続時の取り扱い貨幣データを通知する
#define GLY_STATUS_MACHINE_STANDBY			(GLY_DE_OFFSET + 11)

#define MSG_GLY_DepositFixEvent				(GLY_DE_OFFSET + 12)
#define MSG_GLY_AsyncDepositClosing			(GLY_DE_OFFSET + 13)
#define MSG_GLY_DE_DeviceSettingDataRequest	(GLY_DE_OFFSET + 14)
#define MSG_GLY_DE_DenominationDataRequest	(GLY_DE_OFFSET + 15)
#define MSG_GLY_DE_InformationRead			(GLY_DE_OFFSET + 16)

#define MSG_GLY_DE_AsyncLock				(GLY_DE_OFFSET + 17)//ロック		 2012.10.23 add Ver.0301 課題№00530 suzuki
#define MSG_GLY_DE_AsyncUnLock				(GLY_DE_OFFSET + 18)//アンロック	 2012.11.20 add Ver.0301 課題№00538 suzuki
#define MSG_GLY_DE_AsyncCntStart			(GLY_DE_OFFSET + 19)//計数開始		 2012.11.20 add Ver.0301 課題№00539 suzuki
#define MSG_GLY_DE_ModeDataRequest			(GLY_DE_OFFSET + 20)//モード状態取得 2012.11.05 add Ver.0301 課題№00533 suzuki
#define MSG_GLY_DE_StatusDataRequest		(GLY_DE_OFFSET + 21)//状態取得		 2012.11.05 add Ver.0301 課題№00537 suzuki
#define MSG_GLY_DE_PropertyDataRequest		(GLY_DE_OFFSET + 22)//残留・装置情報 2012.11.06 add Ver.0301 課題№00534 suzuki
#define MSG_GLY_DE_CounterDataRequest		(GLY_DE_OFFSET + 23)//カウンタ情報	 2012.11.07 add Ver.0301 課題№00535 suzuki
#define MSG_GLY_DE_CntEnd					(GLY_DE_OFFSET + 24)//計数停止		 2012.11.21 add Ver.0301 課題№00540 suzuki
#define MSG_GLY_DE_AsyncStore				(GLY_DE_OFFSET + 25)//収納開始		 2012.11.22 add Ver.0301 課題№00542 suzuki
#define MSG_GLY_DE_AsyncCancel				(GLY_DE_OFFSET + 26)//返却開始		 2012.11.22 add Ver.0301 課題№00543 suzuki
#define MSG_GLY_DE_AsyncTransaction			(GLY_DE_OFFSET + 27)//取引通番		 2013.03.07 add Ver.0302 課題№00627 suzuki

//ロック情報
#define GLY_LOCK							(GLY_DE_OFFSET + 200)
#define GLY_UNLOCK							(GLY_DE_OFFSET + 201)

//モード情報
#define GLY_MODE_CERTIFICATION				(GLY_DE_OFFSET + 210)	//認証
#define GLY_MODE_DEPOSIT					(GLY_DE_OFFSET + 211)	//入金
#define GLY_MODE_COUNT						(GLY_DE_OFFSET + 212)	//計数
#define GLY_MODE_MANUAL						(GLY_DE_OFFSET + 213)	//現外
#define GLY_MODE_BATCH						(GLY_DE_OFFSET + 214)	//バッチ
#define GLY_MODE_CLOSE						(GLY_DE_OFFSET + 215)	//締め
#define GLY_MODE_TCLS						(GLY_DE_OFFSET + 216)	//仮締め	2012.12.17 add Ver.0301 課題№00576 suzuki
#define GLY_MODE_CHANGE						(GLY_DE_OFFSET + 217)	//交換
#define GLY_MODE_COLLECTION					(GLY_DE_OFFSET + 218)	//回収
#define GLY_MODE_SET						(GLY_DE_OFFSET + 219)	//設定
#define GLY_MODE_ERR						(GLY_DE_OFFSET + 220)	//ERR
#define GLY_MODE_CURRENCY					(GLY_DE_OFFSET + 221)	//通過切替モード	2013.01.23 add Ver.0301 課題№00594 suzuki
#define GLY_MODE_SECERROR					(GLY_DE_OFFSET + 224)	//重要障害解除

//↓2012.11.15 add Ver.0301 課題№00537 suzuki
//装置状態
#define GLY_MACHINE_WAIT					(GLY_DE_OFFSET + 230)	//コマンド受付可
#define GLY_MACHINE_SPECIFIC				(GLY_DE_OFFSET + 231)	//処理中
#define GLY_MACHINE_PROCESSING				(GLY_DE_OFFSET + 232)	//コマンド受付不可
//↑2012.11.15 add Ver.0301 課題№00537 suzuki

//メカ情報
#define GLY_OPEN							(GLY_DE_OFFSET + 240)
#define GLY_CLOSE							(GLY_DE_OFFSET + 241)
#define GLY_SET								(GLY_DE_OFFSET + 242)
#define GLY_REMOVE							(GLY_DE_OFFSET + 243)
#define GLY_NORMAL							(GLY_DE_OFFSET + 244)	//カセット未フル状態	2013.03.04 add Ver.0302 課題№00625 suzuki

//権限指定
#define GLY_AUTHORITY_BASE					(GLY_DE_OFFSET + 250)	//（使用不可）			2013.01.10 add Ver.0301 課題№00530 suzuki
#define GLY_AUTHORITY_CHECKER				(GLY_DE_OFFSET + 251)	//チェッカー			2013.01.10 add Ver.0301 課題№00530 suzuki
#define GLY_AUTHORITY_MANAGER				(GLY_DE_OFFSET + 252)	//マネージャー			2013.01.10 add Ver.0301 課題№00530 suzuki
#define GLY_AUTHORITY_SECURITY				(GLY_DE_OFFSET + 253)	//警備員				2013.01.10 add Ver.0301 課題№00530 suzuki
#define GLY_AUTHORITY_FREE					(GLY_DE_OFFSET + 259)	//上位指定				2013.01.10 add Ver.0301 課題№00530 suzuki

//計数タイプ
#define GLY_COUNT_DENOMI					(GLY_DE_OFFSET + 260)	//金種識別計数			2013.01.10 add Ver.0301 課題№00530 suzuki
#define GLY_COUNT_CHECK						(GLY_DE_OFFSET + 261)	//商品券計数			2013.01.10 add Ver.0301 課題№00530 suzuki

//プリンタ状態
#define GLY_PRINTER_ERROR					(GLY_DE_OFFSET + 300)	//プリンター障害通知	2012.11.14 add Ver.0301 課題№00536 suzuki
#define GLY_PRINTER_RECOVERY				(GLY_DE_OFFSET + 301)	//プリンター復旧通知	2012.12.03 add Ver.0301 課題№00536 suzuki

//ユーザ設定
#define GLY_SET_ENGLIGH						(GLY_DE_OFFSET + 310)	//英語					2013.01.09 add Ver.0301 課題№00589 suzuki
#define GLY_SET_LOCAL						(GLY_DE_OFFSET + 311)	//現地語				2013.01.09 add Ver.0301 課題№00589 suzuki

//エラーコード
#define GLY_ERROR_NOT_READY					(GLY_DE_OFFSET + 400)	//処理機準備中			2012.11.30 add Ver.0301 課題№00542 suzuki
#define GLY_ERROR_INTEGRAL_ABNORMALITY		(GLY_DE_OFFSET + 401)	//処理機集積状態異常	2013.01.21 add Ver.0301 課題№00592 suzuki

//モード
enum{
	MODE_GLY_DE_CERTIFIC = 0,	//認証モード
	MODE_GLY_DE_DEPOSIT,		//入金モード
	MODE_GLY_DE_COUNT,			//計数モード
	MODE_GLY_DE_MANUAL,			//現外モード
	MODE_GLY_DE_BATCH,			//バッチモード
	MODE_GLY_DE_CLOSE,			//締めモード
	MODE_GLY_DE_TCLS,			//仮締めモード
	MODE_GLY_DE_CHG	,			//交換モード
	MODE_GLY_DE_COLLECT,		//回収モード
	MODE_GLY_DE_SET,			//設定モード
	MODE_GLY_DE_ERR,			//ERRモード
	MODE_CURRENCY,				//通過切替モード	2013.01.23 add Ver.0301 課題№00594 suzuki
	MODE_GLY_DE_SECERROR = 14	//重要障害解除
};

//SR1の値
enum{
	TERM_SR1_100_NORMAL		=0x40,			/* ４０ｈ	正常受信	コマンドを正常に受信し、処理した。*/
	TERM_SR1_100_NOTREADY,					/* ４１ｈ	処理機準備中 */
	TERM_SR1_100_INTEGRALABNORMALITY,		/* ４２ｈ	処理機集積状態異常 */ //2013.01.21 upd Ver.0301 課題№00592 suzuki
	TERM_SR1_100_ERRUNK,					/* ４３ｈ	未定義コマンド	受信したコマンドが未定義であった。*/
	TERM_SR1_100_ERRLGT,					/* ４４ｈ	レングス異常	レングスデータと実際に受信したデータ個数が異なる。 */
	TERM_SR1_100_RESERVE5,					/* ４５ｈ	未使用 */
	TERM_SR1_100_ERREXEC,					/* ４６ｈ	実行不可		受信したコマンドを実行できない状態であった。 */
	TERM_SR1_100_ERRLOCAL,					/* ４７ｈ	ローカル運用中	ローカルキーで操作するモードであった。 */
	TERM_SR1_100_ERROCC,					/* ４８ｈ	他局占有中		他局が処理を行っている状態であった。 */
	TERM_SR1_100_ERRDAT,					/* ４９ｈ	異常データ受信	受信したデータに異常があった。 */
};

//↓2012.11.05 add Ver.0301 課題№00533 suzuki
//bit
enum {
	bit0 = 0x1,		//!<  @brief 0x01 :bit0
	bit1 = 0x2,		//!<  @brief 0x02 :bit1
	bit2 = 0x4,		//!<  @brief 0x04 :bit2
	bit3 = 0x8,		//!<  @brief 0x08 :bit3
	bit4 = 0x10,	//!<  @brief 0x10 :bit4
	bit5 = 0x20,	//!<  @brief 0x20 :bit5
	bit6 = 0x40,	//!<  @brief 0x40 :bit6
	bit7 = 0x80		//!<  @brief 0x80 :bit7
};
//↑2012.11.05 add Ver.0301 課題№00533 suzuki

//↓2012.11.15 add Ver.0301 課題№00537 suzuki
//入金ステップ
enum {
	DEPOSIT_STAT_WAIT	=	0,	//入金待機中状態
	DEPOSIT_STAT_CNT,			//入金計数中状態
	DEPOSIT_STAT_STORWAIT,		//入金収納待ち状態
	DEPOSIT_STAT_STORING,		//入金収納中状態
	DEPOSIT_STAT_RETURN,		//入金返却中状態
	DEPOSIT_STAT_REPRINT,		//入金再印字状態
	DEPOSIT_STAT_IDSET	= 61	//入金時キャンセルID入力待ち
};
//現外ステップ
enum {
	MANU_STAT_WAIT	=	0,		//現外待機中状態
	MANU_STAT_ESCSET,			//現外封筒セット待ち状態
	MANU_STAT_STORING,			//現外収納状態
	MANU_STAT_RETURN,			//現外返却状態
	MANU_STAT_REPRINT			//現外再印字状態
};
//バッチステップ
enum {
	BATCH_STAT_WAIT	=	0,		//バッチ待機状態
	BATCH_STAT_CNT,				//バッチ計数状態
	BATCH_STAT_ACCEPT,			//バッチ確定状態
	BATCH_STAT_RETURN,			//バッチ返却状態
	BATCH_STAT_REPRINT,			//バッチ再印字状態
	BATCH_STAT_SET				//バッチ設定状態
};
//計数ステップ
enum {
	CNT_STAT_WAIT	=	0,		//計数待ち状態
	CNT_STAT_CNT,				//計数状態
	CNT_STAT_ACCEPT,			//計数確定状態
	CNT_STAT_REPRINT,			//計数再印字状態
	CNT_STAT_RETURN				//計数返却状態
};
//締めステップ
enum {
	CLOSE_STAT_WAIT	=	0,		//締め待ち状態
	CLOSE_STAT_ACCEPT,			//締め確定状態
	CLOSE_STAT_REPRINT			//締め再印字状態
};
//回収ステップ
enum {
	CLCT_STEP_WAIT	=	0,		//回収待機状態
	CLCT_STEP_DOOROPEN,			//回収前扉開待ち状態
	CLCT_STEP_CSTREMOVE,		//回収カセット抜取り状態
	CLCT_STEP_CSTSET,			//回収カセットセット状態
	CLCT_STEP_DOORCLOSE,		//回収前扉閉待ち状態
	CLCT_STEP_ACCEPT,			//回収印字状態
	CLCT_STEP_REPRINT,			//回収再印字状態
	CLCT_STEP_CSSTSET			//回収時交換カセット情報入力中状態
};
//交換ステップ
enum {
	CHG_STEP_WAIT	=	0,		//交換待機状態
	CHG_STEP_DOOROPEN,			//交換前扉開待ち状態
	CHG_STEP_CSTREMOVE,			//交換カセット抜取り状態
	CHG_STEP_CSTSET,			//交換カセットセット状態
	CHG_STEP_DOORCLOSE,			//交換前扉閉待ち状態
	CHG_STEP_ACCEPT,			//交換確定状態
	CHG_STEP_REPRINT,			//交換再印字状態
	CHG_STEP_CSSTSET			//交換カセット情報入力中状態
};
//取り込みエラー処理ステップ
enum {
	ERR_SEC_WAIT	=	0,		//待機状態
	ERR_SEC_IDSET,				//ID入力中状態
	ERR_SEC_PASSCHK,			//暗証照合状態
	ERR_SEC_OPEN,				//扉開処理待ち
	ERR_SEC_EXE,				//エラー解除開始
	ERR_SEC_RESET,				//リセット中
	ERR_SEC_PRINTINF,			//エラー情報印字中
	ERR_SEC_STORWAIT,			//収納処理待ち
	ERR_SEC_STOR,				//収納処理中
	ERR_SEC_PRINT,				//解除完了印字状態
	ERR_SEC_PRINTEND,			//解除完了印字完了状態
	ERR_SEC_RSTRETURN,			//リセット開始前残留紙幣抜き取り待ち
	ERR_SEC_RETURNWAIT,			//残留紙幣抜き取り待ち
};
//エラー処理ステップ
enum {
	ERR_NOR_WAIT	= 0,		//待機状態
	ERR_NOR_RESET,				//リセット中
	ERR_NOR_RETURNWAIT			//残留紙幣抜き取り待ち
};
//設定処理ステップ
enum {
	SET_STEP_WAIT	= 0,		//項目選択
	SET_STEP_SLCT,				//詳細設定中
	SET_STEP_BATCH				//バッチ設定
};
//仮締め処理ステップ
enum {
	TCLS_STAT_WAIT	= 0,		//仮締め待ち状態
	TCLS_STAT_ACCEPT			//仮締め印字状態
};
//↑2012.11.15 add Ver.0301 課題№00537 suzuki

#define GLY_DEPOSIT_OPERATORID_ASCIIMAX 16	//2012.07.02 add 課題№00527 suzuki ID9、レジID対応

//↓2012.12.28 add Ver.0301 課題№00585 suzuki
//本体部 I/F　Type
enum {
	IF_TYPE_A	= 0,			//TYPE A
	IF_TYPE_B,					//TYPE B
	IF_TYPE_C					//TYPE C
};
//↑2012.12.28 add Ver.0301 課題№00585 suzuki

/**
* 処理機のエラーイベントを定義する構造体
*/
typedef struct _GLYDEPOSITERROR {
	unsigned int dwErrorCode;		//!< エラーコード
	unsigned int dwErrorType;		//!< エラー分類
	struct tm Time;					//!< 事象発生時刻
	unsigned int EventNumber;		//!< イベント番号
} GLYDEPOSITERROR, *LPGLYDEPOSITERROR;	//!< GLYDEPOSITERROR構造体へのポインタ

/**
* 入金収納確定イベントを定義する構造体
*/
typedef struct _GLYDEPOSITCOUNTER {
	unsigned int EventNumber;		//!< イベント番号
	struct tm Time;					//!< 事象発生時刻
	unsigned int dwSquentialNo;		//!< 締め通番
	unsigned int dwUserID;			//!< 操作者ID
	GLYCOUNTERS DepositData;		//!< 入金機の計数データ関連情報
} GLYDEPOSITCOUNTER, *LPGLYDEPOSITCOUNTER;	//!< GLYDEPOSITCOUNTER構造体へのポインタ
//↓2012.07.02 add 課題№00527 suzuki	ID9、レジID対応
typedef struct _GLYDEPOSITCOUNTER_EX {
	unsigned int EventNumber;						//!< イベント番号
	struct tm Time;									//!< 事象発生時刻
	unsigned int dwSquentialNo;						//!< 締め通番
	unsigned int dwTransactionNo;					//!< 取引番号			2013.03.07 add Ver.0302 課題№626 suzuki
	char chUserID[GLY_DEPOSIT_OPERATORID_ASCIIMAX];	//!< 操作者ID
	GLYCOUNTERS DepositData;						//!< 入金機の計数データ関連情報
} GLYDEPOSITCOUNTER_EX, *LPGLYDEPOSITCOUNTER_EX;	//!< GLYDEPOSITCOUNTER構造体へのポインタ
//↑2012.07.02 add 課題№00527 suzuki	ID9、レジID対応

/**
* 処理機のエラー解除イベントを定義する構造体
*/
typedef struct _GLYDEPOSITCLEARERROR {
	unsigned int dwErrorCode;		//!< エラーコード
	unsigned int dwErrorType;		//!< エラー分類
	struct tm Time;					//!< 事象発生時刻
	unsigned int dwUserID;			//!< 操作者ID
	unsigned int dwSerialID;		//!< エラー現金収納
	unsigned int EventNumber;		//!< イベント番号
} GLYDEPOSITCLEARERROR, *LPGLYDEPOSITCLEARERROR;	//!< GLYDEPOSITCLEARERROR構造体へのポインタ
//↓2012.07.02 add 課題№00527 suzuki	ID9、レジID対応
typedef struct _GLYDEPOSITCLEARERROR_EX {
	unsigned int dwErrorCode;					//!< エラーコード
	unsigned int dwErrorType;					//!< エラー分類
	struct tm Time;								//!< 事象発生時刻
	unsigned int dwTransactionNo;					//!< 取引番号			2013.03.07 add Ver.0302 課題№626 suzuki
	char chUserID[GLY_DEPOSIT_OPERATORID_ASCIIMAX];	//!< 操作者ID
	unsigned int dwSerialID;					//!< エラー現金収納
	unsigned int EventNumber;					//!< イベント番号
} GLYDEPOSITCLEARERROR_EX, *LPGLYDEPOSITCLEARERROR_EX;	//!< GLYDEPOSITCLEARERROR構造体へのポインタ
//↑2012.07.02 add 課題№00527 suzuki	ID9、レジID対応

/**
* DEの個別情報を定義する構造体
*/
typedef struct _GLYDEINFORMATION {
	unsigned int dwInformation;				//!< DE個別情報
} GLYDEINFORMATION, *LPGLYDEINFORMATION;	//!< GLYDEINFORMATION構造体へのポインタ

/**
* カセット個別データを定義する構造体
*/
typedef struct _GLYDEPOSIT_CASSETTE {
	char CassetteID[16];									//!< カセットID
	unsigned int dwTotalCounts;								//!< カセット収納総枚数
	unsigned int dwEnvelopNumber;							//!< 現外入金封筒数
	unsigned int dwStoringErrorCounts;						//!< エラー現金封筒数
	GLYDENOMINATION Envelop[GLY_DEPOSIT_MANUAL_NUM];		//!< 現外項目別金額データ
} GLYDEPOSIT_CASSETTE, *LPGLYDEPOSIT_CASSETTE;				//!< GLYDEPOSIT_CASSETTE構造体へのポインタ

/**
* DEの個別設定データを定義する構造体
*/
typedef struct _GLYDEDEVICESETTINGDATA {
	unsigned int dwCustomerID;								//!< 顧客番号
	unsigned int dwStoreID;									//!< 店舗番号
	unsigned int dwMachineID;								//!< 号機番号
	char ManualDepositName[GLY_DEPOSIT_MANUAL_NUM][20];		//!< 現外項目名称
	char bIFType;											//本体部I/Fタイプ設定	2012.12.28 add Ver.0301 課題№00585 suzuki
} GLYDEDEVICESETTINGDATA, *LPGLYDEDEVICESETTINGDATA;		//!< GLYDEDEVICESETTINGDATA構造体へのポインタ

/**
* 金額情報を定義する構造体
*/
typedef struct _GLYAMOUNT {
	unsigned int ulInteger;				//!< 金額の整数部
	unsigned int ulDecimal;				//!< 金額の小数部
	char cCurrencyID[4];				//!< ISO-4217で基底された通貨の種類を示す３文字の文字列
	int Rev;							//!< 通貨のリビジョン
	GLYVALUEEXP ValueExp;				//!< 通貨の価値
	int Category;						//!< 貨幣のカテゴリ
	GLYSIGNATURE** ppSignature;			//!< 通常NULL(貨幣のイメージデータ・記番号がある場合のみ使用)
	void* misc;							//!< 通常NULL(処理機により、特別な情報を追加したい場合のみ使用)
} GLYAMOUNT, *LPGLYAMOUNT;				//!< GLYAMOUNT構造体へのポインタ

/**
* GLYAMOUNTの集積を定義する構造体
* 計数結果や集積された貨幣等、複数種類の貨幣の集合を金額で示す場合に使用する
*/
typedef struct _GLYAMOUNTS { 
      unsigned int	ulArraySize;		//!< GLYAMOUNTの要素数
      LPGLYAMOUNT	lpAmounts;			//!< GLYAMOUNTの配列
} GLYAMOUNTS, *LPGLYAMOUNTS;			//!< GLYAMOUNTS構造体へのポインタ

/**
* 現外入金の計数データ関連を定義する構造体
*/
typedef struct _GLYDEPOSITMANUALCOUNTER {
	unsigned int EventNumber;			//!< イベント番号
	struct   tm  Time;					//!< 事象発生時刻
	unsigned int dwSquentialNo;			//!< 締め通番
	unsigned int dwUserID;				//!< 操作者ID
	unsigned int dwManualDepositNo;		//!< 現外入金通番
	unsigned int dwID;					//!< 現外項目番号
	GLYAMOUNTS DepositData;				//!< 各カウンタデータ
} GLYDEPOSITMANUALCOUNTER, *LPGLYDEPOSITMANUALCOUNTER;	//!< GLYDEPOSITMANUALCOUNTER構造体へのポインタ
//↓2012.07.02 add 課題№00527 suzuki	ID9、レジID対応
typedef struct _GLYDEPOSITMANUALCOUNTER_EX {
	unsigned int EventNumber;						//!< イベント番号
	struct   tm  Time;								//!< 事象発生時刻
	unsigned int dwSquentialNo;						//!< 締め通番
	unsigned int dwTransactionNo;					//!< 取引番号			2013.03.07 add Ver.0302 課題№626 suzuki
	char chUserID[GLY_DEPOSIT_OPERATORID_ASCIIMAX];	//!< 操作者ID
	unsigned int dwManualDepositNo;					//!< 現外入金通番
	unsigned int dwID;								//!< 現外項目番号
	GLYAMOUNTS DepositData;							//!< 各カウンタデータ
} GLYDEPOSITMANUALCOUNTER_EX, *LPGLYDEPOSITMANUALCOUNTER_EX;	//!< GLYDEPOSITMANUALCOUNTER構造体へのポインタ
//↑2012.07.02 add 課題№00527 suzuki	ID9、レジID対応

//↓2012.10.23 add Ver.0301 課題№00530 suzuki
#define GLY_CSST_ID		12						//上位から実機へ送るカセットID用
typedef struct _GLYLOCK_PARAM{
//↓2012.12.10 upd Ver.0301 課題№00568 suzuki
//	unsigned char	bUserID[14];					//ユーザID
	unsigned char	regi_code[4];					//レジ
	unsigned char	id_code[9];						//ID
	unsigned int	authority;						//権限
//↑2012.12.10 upd Ver.0301 課題№00568 suzuki
	unsigned int	TransactionNumber;				//取引番号		2013.03.07 add Ver.0302 課題№626 suzuki
	unsigned int	mode;							//モード
	unsigned int	currency;						//通貨コード
	unsigned int	Manual_Item;					//現外項目
	unsigned long	Manual_Value;					//現外金額
	unsigned int	Manual_Subsidiary_Value;		//現外補助金額
	unsigned int	Count_Type;						//計数条件
	unsigned char	Batch_Regi;						//バッチ組数
	unsigned char	Batch_Set[GLY_DE_AMOUNT_MAX];	//バッチ設定枚数
	unsigned char	Cassette_Id[GLY_CSST_ID];		//カセットID
//↓2013.01.09 add Ver.0301 課題№00589 suzuki
	unsigned int	UserSet_Contrast;				//コントラスト設定
	unsigned int	UserSet_BackLight;				//バックライト設定
	unsigned int	UserSet_DigitMark;				//ディジットマーク
	unsigned int	UserSet_Language;				//言語設定
	unsigned int	UserSet_Double;					//二枚券レベル設定
//↑2013.01.09 add Ver.0301 課題№00589 suzuki
} GLYLOCK_PARAM, *LPGLYLOCK_PARAM;	// GLYLOCK_DATA構造体へのポインタ

//↑2012.10.23 add Ver.0301 課題№00530 suzuki
//↓2012.11.05 add Ver.0301 課題№00533 suzuki モード状態
typedef struct _GLYMODE{
	unsigned int	dwLockStatus;				//ロック
	unsigned int	dwModeStatus;				//モード
}GLYMODE, *LPGLYMODE;
//↓2012.11.05 add Ver.030x 課題№00xxx suzuki 装置状態
typedef struct _GLYMACHINE{
	unsigned int	dwMachine_Status;			//装置状態
}GLYMACHINE, *LPGLYMACHINE;
//↓2012.11.06 add Ver.0301 課題№00534 suzuki 残留・装置情報
typedef struct _GLYDEPROPERTY{
	unsigned int	dwHPStatus;					//ホッパ
	unsigned int	dwRJStatus;					//リジェクト
	unsigned int	dwEscrowStatus;				//一保
	unsigned int	dwEscrowDoorStatus;			//一保扉
	unsigned int	dwFrontDoorStatus;			//フロントドア
	unsigned int	dwCassetteStatus;			//カセット（状態）
	unsigned int	dwCassette;					//カセット（フル情報）
}GLYDEPROPERTY, *LPGLYDEPROPERTY;

//↓2012.12.21 del Ver.0301 課題№00578 suzuki
////↓2012.11.07 add Ver.0301 課題№00535 suzuki カウンタ情報
//typedef struct _GLYDECOUNTER{
//	GLYDENOMINATION Escrow;						// 計数情報
//	LPGLYCOUNTERS DepositData;					// 入金機のカセット情報
//}GLYDECOUNTER, *LPGLYDECOUNTER;
//↑2012.12.21 del Ver.0301 課題№00578 suzuki

//↓2013.03.07 add Ver.0302 課題№00627 suzuki DE用取引通番
typedef struct _GLYDETRANSACTION{
	unsigned int	dwDeposit;					//入金
	unsigned int	dwManual;					//現外
	unsigned int	dwClose;					//締め
	unsigned int	dwCollect;					//回収取引
	unsigned int	dwChange;					//回収～回収間カセット交換数
	unsigned int	dwClearError;				//重要障害時の封筒入金通番
}GLYDETRANSACTION, *LPGLYDETRANSACTION;
//↑2013.03.07 add Ver.0302 課題№00627 suzuki DE用取引通番


//#ifndef _EMU_
#ifdef _GLY_USE_WINDOW_HANDLE_
#include <windows.h>
DWORD __stdcall GLY_DepositFixEvent(GLYHANDLE h, unsigned int EventNumber);
DWORD __stdcall GLY_DepositClosing(GLYHANDLE h, LPGLYDEPOSITCOUNTER* lppCounters);
DWORD __stdcall GLY_AsyncDepositClosing(GLYHANDLE h, HWND hWnd, LPGLYREQUESTID lpRequestID);
DWORD __stdcall GLY_DE_DeviceSettingDataRequest(GLYHANDLE h, LPGLYDEDEVICESETTINGDATA lpDEDeviceSettingData);
DWORD __stdcall GLY_DE_DenominationDataRequest(GLYHANDLE h, LPGLYDENOMINATION* lppDenomination);
DWORD __stdcall GLY_DE_InformationRead(GLYHANDLE h, LPGLYDEINFORMATION* lppInformation);

//DWORD __stdcall GLY_AsyncDeLock(GLYHANDLE h, HWND hWnd, LPGLYREQUESTID lpRequestID, LPGLYLOCK_PARAM lpprm);
//DWORD __stdcall GLY_DeLock(GLYHANDLE h, LPGLYLOCK_PARAM lpprm);
//DWORD __stdcall GLY_AsyncDeUnLock(GLYHANDLE h, HWND hWnd, LPGLYREQUESTID lpRequestID);
//DWORD __stdcall GLY_DeUnLock(GLYHANDLE h);
#else

/**
* @brief イベントデータ確定要求API
* @param [in] h GLY_Openハンドル
* @param [in] EventNumber イベント番号
* @retval 0 正常終了
* @retval 0以外 エラーコード
*/
int GLY_DepositFixEvent(GLYHANDLE h, unsigned int EventNumber);

/**
* @brief 締めイベントデータ通知(同期型)
* @param [in] h GLY_Openハンドル
* @param [in] lppCounters 締めデータへのポインタ
* @retval 0 正常終了
* @retval 0以外 エラーコード
*/
int GLY_DepositClosing(GLYHANDLE h, LPGLYDEPOSITCOUNTER* lppCounters);

/**
* @brief 締めイベントデータ通知(非同期型)
* @param [in] h GLY_Openハンドル
* @param [in] lppCounters 締めデータへのポインタ
* @param [in] lpRequestID リクエストID
* @retval 0 正常終了
* @retval 0以外 エラーコード
*/
int GLY_AsyncDepositClosing(GLYHANDLE h, GLYCALLBACK pcb, LPGLYREQUESTID lpRequestID);

/**
* @brief 処理機個別データ取得API(同期型)
* @param [in] h GLY_Openハンドル
* @param [in] lppDEDeviceSettingData 処理機設定データへのポインタ
* @retval 0 正常終了
* @retval 0以外 エラーコード
*/
int GLY_DE_DeviceSettingDataRequest(GLYHANDLE h, LPGLYDEDEVICESETTINGDATA* lppDEDeviceSettingData);

/**
* @brief 通貨識別データ取得API
* @param [in] h GLY_Openハンドル
* @param [in] lppDenomination 通貨識別データへのポインタ
* @retval 0 正常終了
* @retval 0以外 エラーコード
*/
int GLY_DE_DenominationDataRequest(GLYHANDLE h, LPGLYDENOMINATION* lppDenomination);

/**
* @brief DE固有情報取得API
* @param [in] h GLY_Openハンドル
* @param [in] lppInformation DE固有情報データへのポインタ
* @retval 0 正常終了
* @retval 0以外 エラーコード
*/
int GLY_DE_InformationRead(GLYHANDLE h, LPGLYDEINFORMATION* lppInformation);

//↓2012.10.23 add Ver.0301 課題№00530 suzuki
/**
* @brief DE ロック処理
* @param [in] h				GLY_Openハンドル
* @param [in] pcb			コールバック関数へのポインタ
* @param [in] lpRequestID	リクエストID
* @param [in] lpprm			APからの入力データ
* @retval 0 正常終了
* @retval 0以外 エラーコード
*/
int GLY_AsyncDeLock(GLYHANDLE h, GLYCALLBACK pcb, LPGLYREQUESTID lpRequestID, LPGLYLOCK_PARAM* lpprm);
/**
* @brief DE ロック処理
* @param [in] h		GLY_Openハンドル
* @param [in] lpprm APからの入力データ
* @retval 0 正常終了
* @retval 0以外 エラーコード
*/
int GLY_DeLock(GLYHANDLE h, LPGLYLOCK_PARAM* lpprm);
//↑2012.10.23 add Ver.0301 課題№00530 suzuki

//↓2012.11.20 add Ver.0301 課題№00538 suzuki
/**
* @brief DE アンロック処理
* @param [in] h GLY_Openハンドル
* @param [in] pcb コールバック関数へのポインタ
* @param [in] lpRequestID	リクエストID
* @retval 0 正常終了
* @retval 0以外 エラーコード
*/
int GLY_AsyncDeUnLock(GLYHANDLE h, GLYCALLBACK pcb, LPGLYREQUESTID lpRequestID);
/**
* @brief DE アンロック処理
* @param [in] h		GLY_Openハンドル
* @retval 0 正常終了
* @retval 0以外 エラーコード
*/
int GLY_DeUnLock(GLYHANDLE h);
//↑2012.11.20 add Ver.0301 課題№00538 suzuki

//↓2012.11.20 add Ver.0301 課題№00539 suzuki
/**
* @brief DE 計数開始処理
* @param [in] h GLY_Openハンドル
* @param [in] pcb コールバック関数へのポインタ
* @param [in] lpRequestID	リクエストID
* @retval 0 正常終了
* @retval 0以外 エラーコード
*/
int GLY_AsyncDeCntStart(GLYHANDLE h, GLYCALLBACK pcb, LPGLYREQUESTID lpRequestID);
/**
* @brief DE 計数開始処理
* @param [in] h		GLY_Openハンドル
* @retval 0 正常終了
* @retval 0以外 エラーコード
*/
int GLY_DeCntStart(GLYHANDLE h, LPGLYDENOMINATION* lppDECounter);
//↑2012.11.20 add Ver.0301 課題№00539 suzuki

//↓2012.11.21 add Ver.0301 課題№00540 suzuki DE用計数停止処理
/**
* @brief DE 計数停止処理
* @param [in] h		GLY_Openハンドル
* @retval 0 正常終了
* @retval 0以外 エラーコード
*/
int GLY_DeCntEnd(GLYHANDLE h);

//↓2012.11.22 add Ver.0301 課題№00542 suzuki
/**
* @brief DE 収納開始処理
* @param [in] h GLY_Openハンドル
* @param [in] pcb コールバック関数へのポインタ
* @param [in] lpRequestID	リクエストID
* @retval 0 正常終了
* @retval 0以外 エラーコード
*/
int GLY_AsyncDeStore(GLYHANDLE h, GLYCALLBACK pcb, LPGLYREQUESTID lpRequestID);
/**
* @brief DE 収納開始処理
* @param [in] h		GLY_Openハンドル
* @retval 0 正常終了
* @retval 0以外 エラーコード
*/
int GLY_DeStore(GLYHANDLE h);
//↑2012.11.22 add Ver.0301 課題№00542 suzuki

//↓2012.11.22 add Ver.0301 課題№00543 suzuki
/**
* @brief DE 返却開始処理
* @param [in] h GLY_Openハンドル
* @param [in] pcb コールバック関数へのポインタ
* @param [in] lpRequestID	リクエストID
* @retval 0 正常終了
* @retval 0以外 エラーコード
*/
int GLY_AsyncDeCancel(GLYHANDLE h, GLYCALLBACK pcb, LPGLYREQUESTID lpRequestID);
/**
* @brief DE 返却開始処理
* @param [in] h		GLY_Openハンドル
* @retval 0 正常終了
* @retval 0以外 エラーコード
*/
int GLY_DeCancel(GLYHANDLE h);
//↑2012.11.22 add Ver.0301 課題№00543 suzuki


//↓2012.11.05 add Ver.0301 課題№00533 suzuki
/**
* @brief DE モード状態
* @param [in] h GLY_Openハンドル
* @param [in] pcb コールバック関数へのポインタ
* @retval 0 正常終了
* @retval 0以外 エラーコード
*/
int GLY_DeGetMode(GLYHANDLE h, LPGLYMODE* lppDEModeData);

//↓2012.11.05 add Ver.030x 課題№00xxx suzuki
/**
* @brief DE 装置状態
* @param [in] h GLY_Openハンドル
* @param [in] pcb コールバック関数へのポインタ
* @retval 0 正常終了
* @retval 0以外 エラーコード
*/
int GLY_DeGetStatus(GLYHANDLE h, LPGLYMACHINE* lppDEStatusData);

//↓2012.11.06 add Ver.0301 課題№00534 suzuki
/**
* @brief DE 残留・装置情報
* @param [in] h GLY_Openハンドル
* @param [in] pcb コールバック関数へのポインタ
* @retval 0 正常終了
* @retval 0以外 エラーコード
*/
int GLY_DeGetProperty(GLYHANDLE h, LPGLYDEPROPERTY* lppDEPropertyData);

//↓2012.11.07 add Ver.0301 課題№00535 suzuki
/**
* @brief DE カウント情報
* @param [in] h GLY_Openハンドル
* @param [in] pcb コールバック関数へのポインタ
* @retval 0 正常終了
* @retval 0以外 エラーコード
*/
//↓2012.12.21 upd Ver.0301 課題№00578 suzuki
//int GLY_DeGetCounter(GLYHANDLE h, LPGLYDECOUNTER* lppDECounterData);
int GLY_DeGetEscrowCounter(GLYHANDLE h, LPGLYDENOMINATION* lppDECounter);

//↓2013.03.07 add Ver.0302 課題№00627 suzuki DE用取引通番
/**
* @brief DE 取引通番
* @param [in] h GLY_Openハンドル
* @param [in] pcb コールバック関数へのポインタ
* @param [in] lpRequestID	リクエストID
* @retval 0 正常終了
* @retval 0以外 エラーコード
*/
int GLY_AsyncDeGetTransaction(GLYHANDLE h, GLYCALLBACK hWnd, LPGLYREQUESTID lpRequestID);

/**
* @brief DE 取引通番
* @param [in] h GLY_Openハンドル
* @param [in] pcb コールバック関数へのポインタ
* @retval 0 正常終了
* @retval 0以外 エラーコード
*/
int GLY_DeGetTransaction(GLYHANDLE h, LPGLYDETRANSACTION* lppDETransaction);

#endif	// _GLY_USE_WINDOW_HANDLE_

#ifdef __cplusplus
}
#endif

#ifdef	WIN32
#pragma pack(pop)
#endif

#endif // __GLY_DE_header__
