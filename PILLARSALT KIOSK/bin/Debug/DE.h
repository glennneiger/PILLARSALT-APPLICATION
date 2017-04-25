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
#define GLY_DEPOSIT_OPERATORID_MAX	9                             // ����NULL
#define GLY_LOG_NUM_MAX				15
#define GLY_NOWAIT_STATUS_NUM_MAX	2
#define GLY_WAIT_STATUS_NUM_MAX		8
#define GLY_SERIAL_BUFFER_MAX		512
#define GLY_DE_MAX_SERIAL			999
#define	GLY_DE_AMOUNT_MAX			64	//2012.11.28 add Ver.0301 �ۑ臂00535 suzuki
#define	GLY_DE_LOCK_BASE_LEN		12	//2013.03.07 add Ver.0302 �ۑ臂00626 suzuki

#define GLY_DEPOSIT_ERROR					(GLY_DE_OFFSET + 1)	// �����@���G���[�����m�������ɒʒm����
#define GLY_DEPOSIT_COUNTRESULT				(GLY_DE_OFFSET + 2)	// �������ʂ�ʒm����
#define GLY_DEPOSIT_MANUALCOUNT				(GLY_DE_OFFSET + 3)	// ���O�������ʂ�ʒm����
#define GLY_DEPOSIT_CLOSING					(GLY_DE_OFFSET + 4)	// ���ߌ��ʂ�ʒm����
#define GLY_DEPOSIT_COLLECT					(GLY_DE_OFFSET + 5)	// ������ʂ�ʒm����
#define GLY_DEPOSIT_CASSETTECHANGE			(GLY_DE_OFFSET + 6)	// �J�Z�b�g�������ʂ�ʒm����
#define GLY_DEPOSIT_CLEARERROR				(GLY_DE_OFFSET + 7)	// ��Q�̉������ʂ�ʒm����
#define GLY_DEPOSIT_WITHOUTSTORE			(GLY_DE_OFFSET + 8)	// �������ʂ�ʒm����(���[����)

#define GLY_DE_DEVICESETTINGDATA			(GLY_DE_OFFSET + 9)	// �ڑ����̐ݒ�f�[�^��ʒm����
#define GLY_DE_DENOMINATIONDATA				(GLY_DE_OFFSET + 10)// �ڑ����̎�舵���ݕ��f�[�^��ʒm����
#define GLY_STATUS_MACHINE_STANDBY			(GLY_DE_OFFSET + 11)

#define MSG_GLY_DepositFixEvent				(GLY_DE_OFFSET + 12)
#define MSG_GLY_AsyncDepositClosing			(GLY_DE_OFFSET + 13)
#define MSG_GLY_DE_DeviceSettingDataRequest	(GLY_DE_OFFSET + 14)
#define MSG_GLY_DE_DenominationDataRequest	(GLY_DE_OFFSET + 15)
#define MSG_GLY_DE_InformationRead			(GLY_DE_OFFSET + 16)

#define MSG_GLY_DE_AsyncLock				(GLY_DE_OFFSET + 17)//���b�N		 2012.10.23 add Ver.0301 �ۑ臂00530 suzuki
#define MSG_GLY_DE_AsyncUnLock				(GLY_DE_OFFSET + 18)//�A�����b�N	 2012.11.20 add Ver.0301 �ۑ臂00538 suzuki
#define MSG_GLY_DE_AsyncCntStart			(GLY_DE_OFFSET + 19)//�v���J�n		 2012.11.20 add Ver.0301 �ۑ臂00539 suzuki
#define MSG_GLY_DE_ModeDataRequest			(GLY_DE_OFFSET + 20)//���[�h��Ԏ擾 2012.11.05 add Ver.0301 �ۑ臂00533 suzuki
#define MSG_GLY_DE_StatusDataRequest		(GLY_DE_OFFSET + 21)//��Ԏ擾		 2012.11.05 add Ver.0301 �ۑ臂00537 suzuki
#define MSG_GLY_DE_PropertyDataRequest		(GLY_DE_OFFSET + 22)//�c���E���u��� 2012.11.06 add Ver.0301 �ۑ臂00534 suzuki
#define MSG_GLY_DE_CounterDataRequest		(GLY_DE_OFFSET + 23)//�J�E���^���	 2012.11.07 add Ver.0301 �ۑ臂00535 suzuki
#define MSG_GLY_DE_CntEnd					(GLY_DE_OFFSET + 24)//�v����~		 2012.11.21 add Ver.0301 �ۑ臂00540 suzuki
#define MSG_GLY_DE_AsyncStore				(GLY_DE_OFFSET + 25)//���[�J�n		 2012.11.22 add Ver.0301 �ۑ臂00542 suzuki
#define MSG_GLY_DE_AsyncCancel				(GLY_DE_OFFSET + 26)//�ԋp�J�n		 2012.11.22 add Ver.0301 �ۑ臂00543 suzuki
#define MSG_GLY_DE_AsyncTransaction			(GLY_DE_OFFSET + 27)//����ʔ�		 2013.03.07 add Ver.0302 �ۑ臂00627 suzuki

//���b�N���
#define GLY_LOCK							(GLY_DE_OFFSET + 200)
#define GLY_UNLOCK							(GLY_DE_OFFSET + 201)

//���[�h���
#define GLY_MODE_CERTIFICATION				(GLY_DE_OFFSET + 210)	//�F��
#define GLY_MODE_DEPOSIT					(GLY_DE_OFFSET + 211)	//����
#define GLY_MODE_COUNT						(GLY_DE_OFFSET + 212)	//�v��
#define GLY_MODE_MANUAL						(GLY_DE_OFFSET + 213)	//���O
#define GLY_MODE_BATCH						(GLY_DE_OFFSET + 214)	//�o�b�`
#define GLY_MODE_CLOSE						(GLY_DE_OFFSET + 215)	//����
#define GLY_MODE_TCLS						(GLY_DE_OFFSET + 216)	//������	2012.12.17 add Ver.0301 �ۑ臂00576 suzuki
#define GLY_MODE_CHANGE						(GLY_DE_OFFSET + 217)	//����
#define GLY_MODE_COLLECTION					(GLY_DE_OFFSET + 218)	//���
#define GLY_MODE_SET						(GLY_DE_OFFSET + 219)	//�ݒ�
#define GLY_MODE_ERR						(GLY_DE_OFFSET + 220)	//ERR
#define GLY_MODE_CURRENCY					(GLY_DE_OFFSET + 221)	//�ʉߐؑփ��[�h	2013.01.23 add Ver.0301 �ۑ臂00594 suzuki
#define GLY_MODE_SECERROR					(GLY_DE_OFFSET + 224)	//�d�v��Q����

//��2012.11.15 add Ver.0301 �ۑ臂00537 suzuki
//���u���
#define GLY_MACHINE_WAIT					(GLY_DE_OFFSET + 230)	//�R�}���h��t��
#define GLY_MACHINE_SPECIFIC				(GLY_DE_OFFSET + 231)	//������
#define GLY_MACHINE_PROCESSING				(GLY_DE_OFFSET + 232)	//�R�}���h��t�s��
//��2012.11.15 add Ver.0301 �ۑ臂00537 suzuki

//���J���
#define GLY_OPEN							(GLY_DE_OFFSET + 240)
#define GLY_CLOSE							(GLY_DE_OFFSET + 241)
#define GLY_SET								(GLY_DE_OFFSET + 242)
#define GLY_REMOVE							(GLY_DE_OFFSET + 243)
#define GLY_NORMAL							(GLY_DE_OFFSET + 244)	//�J�Z�b�g���t�����	2013.03.04 add Ver.0302 �ۑ臂00625 suzuki

//�����w��
#define GLY_AUTHORITY_BASE					(GLY_DE_OFFSET + 250)	//�i�g�p�s�j			2013.01.10 add Ver.0301 �ۑ臂00530 suzuki
#define GLY_AUTHORITY_CHECKER				(GLY_DE_OFFSET + 251)	//�`�F�b�J�[			2013.01.10 add Ver.0301 �ۑ臂00530 suzuki
#define GLY_AUTHORITY_MANAGER				(GLY_DE_OFFSET + 252)	//�}�l�[�W���[			2013.01.10 add Ver.0301 �ۑ臂00530 suzuki
#define GLY_AUTHORITY_SECURITY				(GLY_DE_OFFSET + 253)	//�x����				2013.01.10 add Ver.0301 �ۑ臂00530 suzuki
#define GLY_AUTHORITY_FREE					(GLY_DE_OFFSET + 259)	//��ʎw��				2013.01.10 add Ver.0301 �ۑ臂00530 suzuki

//�v���^�C�v
#define GLY_COUNT_DENOMI					(GLY_DE_OFFSET + 260)	//���펯�ʌv��			2013.01.10 add Ver.0301 �ۑ臂00530 suzuki
#define GLY_COUNT_CHECK						(GLY_DE_OFFSET + 261)	//���i���v��			2013.01.10 add Ver.0301 �ۑ臂00530 suzuki

//�v�����^���
#define GLY_PRINTER_ERROR					(GLY_DE_OFFSET + 300)	//�v�����^�[��Q�ʒm	2012.11.14 add Ver.0301 �ۑ臂00536 suzuki
#define GLY_PRINTER_RECOVERY				(GLY_DE_OFFSET + 301)	//�v�����^�[�����ʒm	2012.12.03 add Ver.0301 �ۑ臂00536 suzuki

//���[�U�ݒ�
#define GLY_SET_ENGLIGH						(GLY_DE_OFFSET + 310)	//�p��					2013.01.09 add Ver.0301 �ۑ臂00589 suzuki
#define GLY_SET_LOCAL						(GLY_DE_OFFSET + 311)	//���n��				2013.01.09 add Ver.0301 �ۑ臂00589 suzuki

//�G���[�R�[�h
#define GLY_ERROR_NOT_READY					(GLY_DE_OFFSET + 400)	//�����@������			2012.11.30 add Ver.0301 �ۑ臂00542 suzuki
#define GLY_ERROR_INTEGRAL_ABNORMALITY		(GLY_DE_OFFSET + 401)	//�����@�W�Ϗ�Ԉُ�	2013.01.21 add Ver.0301 �ۑ臂00592 suzuki

//���[�h
enum{
	MODE_GLY_DE_CERTIFIC = 0,	//�F�؃��[�h
	MODE_GLY_DE_DEPOSIT,		//�������[�h
	MODE_GLY_DE_COUNT,			//�v�����[�h
	MODE_GLY_DE_MANUAL,			//���O���[�h
	MODE_GLY_DE_BATCH,			//�o�b�`���[�h
	MODE_GLY_DE_CLOSE,			//���߃��[�h
	MODE_GLY_DE_TCLS,			//�����߃��[�h
	MODE_GLY_DE_CHG	,			//�������[�h
	MODE_GLY_DE_COLLECT,		//������[�h
	MODE_GLY_DE_SET,			//�ݒ胂�[�h
	MODE_GLY_DE_ERR,			//ERR���[�h
	MODE_CURRENCY,				//�ʉߐؑփ��[�h	2013.01.23 add Ver.0301 �ۑ臂00594 suzuki
	MODE_GLY_DE_SECERROR = 14	//�d�v��Q����
};

//SR1�̒l
enum{
	TERM_SR1_100_NORMAL		=0x40,			/* �S�O��	�����M	�R�}���h�𐳏�Ɏ�M���A���������B*/
	TERM_SR1_100_NOTREADY,					/* �S�P��	�����@������ */
	TERM_SR1_100_INTEGRALABNORMALITY,		/* �S�Q��	�����@�W�Ϗ�Ԉُ� */ //2013.01.21 upd Ver.0301 �ۑ臂00592 suzuki
	TERM_SR1_100_ERRUNK,					/* �S�R��	����`�R�}���h	��M�����R�}���h������`�ł������B*/
	TERM_SR1_100_ERRLGT,					/* �S�S��	�����O�X�ُ�	�����O�X�f�[�^�Ǝ��ۂɎ�M�����f�[�^�����قȂ�B */
	TERM_SR1_100_RESERVE5,					/* �S�T��	���g�p */
	TERM_SR1_100_ERREXEC,					/* �S�U��	���s�s��		��M�����R�}���h�����s�ł��Ȃ���Ԃł������B */
	TERM_SR1_100_ERRLOCAL,					/* �S�V��	���[�J���^�p��	���[�J���L�[�ő��삷�郂�[�h�ł������B */
	TERM_SR1_100_ERROCC,					/* �S�W��	���ǐ�L��		���ǂ��������s���Ă����Ԃł������B */
	TERM_SR1_100_ERRDAT,					/* �S�X��	�ُ�f�[�^��M	��M�����f�[�^�Ɉُ킪�������B */
};

//��2012.11.05 add Ver.0301 �ۑ臂00533 suzuki
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
//��2012.11.05 add Ver.0301 �ۑ臂00533 suzuki

//��2012.11.15 add Ver.0301 �ۑ臂00537 suzuki
//�����X�e�b�v
enum {
	DEPOSIT_STAT_WAIT	=	0,	//�����ҋ@�����
	DEPOSIT_STAT_CNT,			//�����v�������
	DEPOSIT_STAT_STORWAIT,		//�������[�҂����
	DEPOSIT_STAT_STORING,		//�������[�����
	DEPOSIT_STAT_RETURN,		//�����ԋp�����
	DEPOSIT_STAT_REPRINT,		//�����Ĉ󎚏��
	DEPOSIT_STAT_IDSET	= 61	//�������L�����Z��ID���͑҂�
};
//���O�X�e�b�v
enum {
	MANU_STAT_WAIT	=	0,		//���O�ҋ@�����
	MANU_STAT_ESCSET,			//���O�����Z�b�g�҂����
	MANU_STAT_STORING,			//���O���[���
	MANU_STAT_RETURN,			//���O�ԋp���
	MANU_STAT_REPRINT			//���O�Ĉ󎚏��
};
//�o�b�`�X�e�b�v
enum {
	BATCH_STAT_WAIT	=	0,		//�o�b�`�ҋ@���
	BATCH_STAT_CNT,				//�o�b�`�v�����
	BATCH_STAT_ACCEPT,			//�o�b�`�m����
	BATCH_STAT_RETURN,			//�o�b�`�ԋp���
	BATCH_STAT_REPRINT,			//�o�b�`�Ĉ󎚏��
	BATCH_STAT_SET				//�o�b�`�ݒ���
};
//�v���X�e�b�v
enum {
	CNT_STAT_WAIT	=	0,		//�v���҂����
	CNT_STAT_CNT,				//�v�����
	CNT_STAT_ACCEPT,			//�v���m����
	CNT_STAT_REPRINT,			//�v���Ĉ󎚏��
	CNT_STAT_RETURN				//�v���ԋp���
};
//���߃X�e�b�v
enum {
	CLOSE_STAT_WAIT	=	0,		//���ߑ҂����
	CLOSE_STAT_ACCEPT,			//���ߊm����
	CLOSE_STAT_REPRINT			//���ߍĈ󎚏��
};
//����X�e�b�v
enum {
	CLCT_STEP_WAIT	=	0,		//����ҋ@���
	CLCT_STEP_DOOROPEN,			//����O���J�҂����
	CLCT_STEP_CSTREMOVE,		//����J�Z�b�g�������
	CLCT_STEP_CSTSET,			//����J�Z�b�g�Z�b�g���
	CLCT_STEP_DOORCLOSE,		//����O���҂����
	CLCT_STEP_ACCEPT,			//����󎚏��
	CLCT_STEP_REPRINT,			//����Ĉ󎚏��
	CLCT_STEP_CSSTSET			//����������J�Z�b�g�����͒����
};
//�����X�e�b�v
enum {
	CHG_STEP_WAIT	=	0,		//�����ҋ@���
	CHG_STEP_DOOROPEN,			//�����O���J�҂����
	CHG_STEP_CSTREMOVE,			//�����J�Z�b�g�������
	CHG_STEP_CSTSET,			//�����J�Z�b�g�Z�b�g���
	CHG_STEP_DOORCLOSE,			//�����O���҂����
	CHG_STEP_ACCEPT,			//�����m����
	CHG_STEP_REPRINT,			//�����Ĉ󎚏��
	CHG_STEP_CSSTSET			//�����J�Z�b�g�����͒����
};
//��荞�݃G���[�����X�e�b�v
enum {
	ERR_SEC_WAIT	=	0,		//�ҋ@���
	ERR_SEC_IDSET,				//ID���͒����
	ERR_SEC_PASSCHK,			//�Ï؏ƍ����
	ERR_SEC_OPEN,				//���J�����҂�
	ERR_SEC_EXE,				//�G���[�����J�n
	ERR_SEC_RESET,				//���Z�b�g��
	ERR_SEC_PRINTINF,			//�G���[���󎚒�
	ERR_SEC_STORWAIT,			//���[�����҂�
	ERR_SEC_STOR,				//���[������
	ERR_SEC_PRINT,				//���������󎚏��
	ERR_SEC_PRINTEND,			//���������󎚊������
	ERR_SEC_RSTRETURN,			//���Z�b�g�J�n�O�c�������������҂�
	ERR_SEC_RETURNWAIT,			//�c�������������҂�
};
//�G���[�����X�e�b�v
enum {
	ERR_NOR_WAIT	= 0,		//�ҋ@���
	ERR_NOR_RESET,				//���Z�b�g��
	ERR_NOR_RETURNWAIT			//�c�������������҂�
};
//�ݒ菈���X�e�b�v
enum {
	SET_STEP_WAIT	= 0,		//���ڑI��
	SET_STEP_SLCT,				//�ڍאݒ蒆
	SET_STEP_BATCH				//�o�b�`�ݒ�
};
//�����ߏ����X�e�b�v
enum {
	TCLS_STAT_WAIT	= 0,		//�����ߑ҂����
	TCLS_STAT_ACCEPT			//�����߈󎚏��
};
//��2012.11.15 add Ver.0301 �ۑ臂00537 suzuki

#define GLY_DEPOSIT_OPERATORID_ASCIIMAX 16	//2012.07.02 add �ۑ臂00527 suzuki ID9�A���WID�Ή�

//��2012.12.28 add Ver.0301 �ۑ臂00585 suzuki
//�{�̕� I/F�@Type
enum {
	IF_TYPE_A	= 0,			//TYPE A
	IF_TYPE_B,					//TYPE B
	IF_TYPE_C					//TYPE C
};
//��2012.12.28 add Ver.0301 �ۑ臂00585 suzuki

/**
* �����@�̃G���[�C�x���g���`����\����
*/
typedef struct _GLYDEPOSITERROR {
	unsigned int dwErrorCode;		//!< �G���[�R�[�h
	unsigned int dwErrorType;		//!< �G���[����
	struct tm Time;					//!< ���۔�������
	unsigned int EventNumber;		//!< �C�x���g�ԍ�
} GLYDEPOSITERROR, *LPGLYDEPOSITERROR;	//!< GLYDEPOSITERROR�\���̂ւ̃|�C���^

/**
* �������[�m��C�x���g���`����\����
*/
typedef struct _GLYDEPOSITCOUNTER {
	unsigned int EventNumber;		//!< �C�x���g�ԍ�
	struct tm Time;					//!< ���۔�������
	unsigned int dwSquentialNo;		//!< ���ߒʔ�
	unsigned int dwUserID;			//!< �����ID
	GLYCOUNTERS DepositData;		//!< �����@�̌v���f�[�^�֘A���
} GLYDEPOSITCOUNTER, *LPGLYDEPOSITCOUNTER;	//!< GLYDEPOSITCOUNTER�\���̂ւ̃|�C���^
//��2012.07.02 add �ۑ臂00527 suzuki	ID9�A���WID�Ή�
typedef struct _GLYDEPOSITCOUNTER_EX {
	unsigned int EventNumber;						//!< �C�x���g�ԍ�
	struct tm Time;									//!< ���۔�������
	unsigned int dwSquentialNo;						//!< ���ߒʔ�
	unsigned int dwTransactionNo;					//!< ����ԍ�			2013.03.07 add Ver.0302 �ۑ臂626 suzuki
	char chUserID[GLY_DEPOSIT_OPERATORID_ASCIIMAX];	//!< �����ID
	GLYCOUNTERS DepositData;						//!< �����@�̌v���f�[�^�֘A���
} GLYDEPOSITCOUNTER_EX, *LPGLYDEPOSITCOUNTER_EX;	//!< GLYDEPOSITCOUNTER�\���̂ւ̃|�C���^
//��2012.07.02 add �ۑ臂00527 suzuki	ID9�A���WID�Ή�

/**
* �����@�̃G���[�����C�x���g���`����\����
*/
typedef struct _GLYDEPOSITCLEARERROR {
	unsigned int dwErrorCode;		//!< �G���[�R�[�h
	unsigned int dwErrorType;		//!< �G���[����
	struct tm Time;					//!< ���۔�������
	unsigned int dwUserID;			//!< �����ID
	unsigned int dwSerialID;		//!< �G���[�������[
	unsigned int EventNumber;		//!< �C�x���g�ԍ�
} GLYDEPOSITCLEARERROR, *LPGLYDEPOSITCLEARERROR;	//!< GLYDEPOSITCLEARERROR�\���̂ւ̃|�C���^
//��2012.07.02 add �ۑ臂00527 suzuki	ID9�A���WID�Ή�
typedef struct _GLYDEPOSITCLEARERROR_EX {
	unsigned int dwErrorCode;					//!< �G���[�R�[�h
	unsigned int dwErrorType;					//!< �G���[����
	struct tm Time;								//!< ���۔�������
	unsigned int dwTransactionNo;					//!< ����ԍ�			2013.03.07 add Ver.0302 �ۑ臂626 suzuki
	char chUserID[GLY_DEPOSIT_OPERATORID_ASCIIMAX];	//!< �����ID
	unsigned int dwSerialID;					//!< �G���[�������[
	unsigned int EventNumber;					//!< �C�x���g�ԍ�
} GLYDEPOSITCLEARERROR_EX, *LPGLYDEPOSITCLEARERROR_EX;	//!< GLYDEPOSITCLEARERROR�\���̂ւ̃|�C���^
//��2012.07.02 add �ۑ臂00527 suzuki	ID9�A���WID�Ή�

/**
* DE�̌ʏ����`����\����
*/
typedef struct _GLYDEINFORMATION {
	unsigned int dwInformation;				//!< DE�ʏ��
} GLYDEINFORMATION, *LPGLYDEINFORMATION;	//!< GLYDEINFORMATION�\���̂ւ̃|�C���^

/**
* �J�Z�b�g�ʃf�[�^���`����\����
*/
typedef struct _GLYDEPOSIT_CASSETTE {
	char CassetteID[16];									//!< �J�Z�b�gID
	unsigned int dwTotalCounts;								//!< �J�Z�b�g���[������
	unsigned int dwEnvelopNumber;							//!< ���O����������
	unsigned int dwStoringErrorCounts;						//!< �G���[����������
	GLYDENOMINATION Envelop[GLY_DEPOSIT_MANUAL_NUM];		//!< ���O���ڕʋ��z�f�[�^
} GLYDEPOSIT_CASSETTE, *LPGLYDEPOSIT_CASSETTE;				//!< GLYDEPOSIT_CASSETTE�\���̂ւ̃|�C���^

/**
* DE�̌ʐݒ�f�[�^���`����\����
*/
typedef struct _GLYDEDEVICESETTINGDATA {
	unsigned int dwCustomerID;								//!< �ڋq�ԍ�
	unsigned int dwStoreID;									//!< �X�ܔԍ�
	unsigned int dwMachineID;								//!< ���@�ԍ�
	char ManualDepositName[GLY_DEPOSIT_MANUAL_NUM][20];		//!< ���O���ږ���
	char bIFType;											//�{�̕�I/F�^�C�v�ݒ�	2012.12.28 add Ver.0301 �ۑ臂00585 suzuki
} GLYDEDEVICESETTINGDATA, *LPGLYDEDEVICESETTINGDATA;		//!< GLYDEDEVICESETTINGDATA�\���̂ւ̃|�C���^

/**
* ���z�����`����\����
*/
typedef struct _GLYAMOUNT {
	unsigned int ulInteger;				//!< ���z�̐�����
	unsigned int ulDecimal;				//!< ���z�̏�����
	char cCurrencyID[4];				//!< ISO-4217�Ŋ�ꂳ�ꂽ�ʉ݂̎�ނ������R�����̕�����
	int Rev;							//!< �ʉ݂̃��r�W����
	GLYVALUEEXP ValueExp;				//!< �ʉ݂̉��l
	int Category;						//!< �ݕ��̃J�e�S��
	GLYSIGNATURE** ppSignature;			//!< �ʏ�NULL(�ݕ��̃C���[�W�f�[�^�E�L�ԍ�������ꍇ�̂ݎg�p)
	void* misc;							//!< �ʏ�NULL(�����@�ɂ��A���ʂȏ���ǉ��������ꍇ�̂ݎg�p)
} GLYAMOUNT, *LPGLYAMOUNT;				//!< GLYAMOUNT�\���̂ւ̃|�C���^

/**
* GLYAMOUNT�̏W�ς��`����\����
* �v�����ʂ�W�ς��ꂽ�ݕ����A������ނ̉ݕ��̏W�������z�Ŏ����ꍇ�Ɏg�p����
*/
typedef struct _GLYAMOUNTS { 
      unsigned int	ulArraySize;		//!< GLYAMOUNT�̗v�f��
      LPGLYAMOUNT	lpAmounts;			//!< GLYAMOUNT�̔z��
} GLYAMOUNTS, *LPGLYAMOUNTS;			//!< GLYAMOUNTS�\���̂ւ̃|�C���^

/**
* ���O�����̌v���f�[�^�֘A���`����\����
*/
typedef struct _GLYDEPOSITMANUALCOUNTER {
	unsigned int EventNumber;			//!< �C�x���g�ԍ�
	struct   tm  Time;					//!< ���۔�������
	unsigned int dwSquentialNo;			//!< ���ߒʔ�
	unsigned int dwUserID;				//!< �����ID
	unsigned int dwManualDepositNo;		//!< ���O�����ʔ�
	unsigned int dwID;					//!< ���O���ڔԍ�
	GLYAMOUNTS DepositData;				//!< �e�J�E���^�f�[�^
} GLYDEPOSITMANUALCOUNTER, *LPGLYDEPOSITMANUALCOUNTER;	//!< GLYDEPOSITMANUALCOUNTER�\���̂ւ̃|�C���^
//��2012.07.02 add �ۑ臂00527 suzuki	ID9�A���WID�Ή�
typedef struct _GLYDEPOSITMANUALCOUNTER_EX {
	unsigned int EventNumber;						//!< �C�x���g�ԍ�
	struct   tm  Time;								//!< ���۔�������
	unsigned int dwSquentialNo;						//!< ���ߒʔ�
	unsigned int dwTransactionNo;					//!< ����ԍ�			2013.03.07 add Ver.0302 �ۑ臂626 suzuki
	char chUserID[GLY_DEPOSIT_OPERATORID_ASCIIMAX];	//!< �����ID
	unsigned int dwManualDepositNo;					//!< ���O�����ʔ�
	unsigned int dwID;								//!< ���O���ڔԍ�
	GLYAMOUNTS DepositData;							//!< �e�J�E���^�f�[�^
} GLYDEPOSITMANUALCOUNTER_EX, *LPGLYDEPOSITMANUALCOUNTER_EX;	//!< GLYDEPOSITMANUALCOUNTER�\���̂ւ̃|�C���^
//��2012.07.02 add �ۑ臂00527 suzuki	ID9�A���WID�Ή�

//��2012.10.23 add Ver.0301 �ۑ臂00530 suzuki
#define GLY_CSST_ID		12						//��ʂ�����@�֑���J�Z�b�gID�p
typedef struct _GLYLOCK_PARAM{
//��2012.12.10 upd Ver.0301 �ۑ臂00568 suzuki
//	unsigned char	bUserID[14];					//���[�UID
	unsigned char	regi_code[4];					//���W
	unsigned char	id_code[9];						//ID
	unsigned int	authority;						//����
//��2012.12.10 upd Ver.0301 �ۑ臂00568 suzuki
	unsigned int	TransactionNumber;				//����ԍ�		2013.03.07 add Ver.0302 �ۑ臂626 suzuki
	unsigned int	mode;							//���[�h
	unsigned int	currency;						//�ʉ݃R�[�h
	unsigned int	Manual_Item;					//���O����
	unsigned long	Manual_Value;					//���O���z
	unsigned int	Manual_Subsidiary_Value;		//���O�⏕���z
	unsigned int	Count_Type;						//�v������
	unsigned char	Batch_Regi;						//�o�b�`�g��
	unsigned char	Batch_Set[GLY_DE_AMOUNT_MAX];	//�o�b�`�ݒ薇��
	unsigned char	Cassette_Id[GLY_CSST_ID];		//�J�Z�b�gID
//��2013.01.09 add Ver.0301 �ۑ臂00589 suzuki
	unsigned int	UserSet_Contrast;				//�R���g���X�g�ݒ�
	unsigned int	UserSet_BackLight;				//�o�b�N���C�g�ݒ�
	unsigned int	UserSet_DigitMark;				//�f�B�W�b�g�}�[�N
	unsigned int	UserSet_Language;				//����ݒ�
	unsigned int	UserSet_Double;					//�񖇌����x���ݒ�
//��2013.01.09 add Ver.0301 �ۑ臂00589 suzuki
} GLYLOCK_PARAM, *LPGLYLOCK_PARAM;	// GLYLOCK_DATA�\���̂ւ̃|�C���^

//��2012.10.23 add Ver.0301 �ۑ臂00530 suzuki
//��2012.11.05 add Ver.0301 �ۑ臂00533 suzuki ���[�h���
typedef struct _GLYMODE{
	unsigned int	dwLockStatus;				//���b�N
	unsigned int	dwModeStatus;				//���[�h
}GLYMODE, *LPGLYMODE;
//��2012.11.05 add Ver.030x �ۑ臂00xxx suzuki ���u���
typedef struct _GLYMACHINE{
	unsigned int	dwMachine_Status;			//���u���
}GLYMACHINE, *LPGLYMACHINE;
//��2012.11.06 add Ver.0301 �ۑ臂00534 suzuki �c���E���u���
typedef struct _GLYDEPROPERTY{
	unsigned int	dwHPStatus;					//�z�b�p
	unsigned int	dwRJStatus;					//���W�F�N�g
	unsigned int	dwEscrowStatus;				//���
	unsigned int	dwEscrowDoorStatus;			//��۔�
	unsigned int	dwFrontDoorStatus;			//�t�����g�h�A
	unsigned int	dwCassetteStatus;			//�J�Z�b�g�i��ԁj
	unsigned int	dwCassette;					//�J�Z�b�g�i�t�����j
}GLYDEPROPERTY, *LPGLYDEPROPERTY;

//��2012.12.21 del Ver.0301 �ۑ臂00578 suzuki
////��2012.11.07 add Ver.0301 �ۑ臂00535 suzuki �J�E���^���
//typedef struct _GLYDECOUNTER{
//	GLYDENOMINATION Escrow;						// �v�����
//	LPGLYCOUNTERS DepositData;					// �����@�̃J�Z�b�g���
//}GLYDECOUNTER, *LPGLYDECOUNTER;
//��2012.12.21 del Ver.0301 �ۑ臂00578 suzuki

//��2013.03.07 add Ver.0302 �ۑ臂00627 suzuki DE�p����ʔ�
typedef struct _GLYDETRANSACTION{
	unsigned int	dwDeposit;					//����
	unsigned int	dwManual;					//���O
	unsigned int	dwClose;					//����
	unsigned int	dwCollect;					//������
	unsigned int	dwChange;					//����`����ԃJ�Z�b�g������
	unsigned int	dwClearError;				//�d�v��Q���̕��������ʔ�
}GLYDETRANSACTION, *LPGLYDETRANSACTION;
//��2013.03.07 add Ver.0302 �ۑ臂00627 suzuki DE�p����ʔ�


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
* @brief �C�x���g�f�[�^�m��v��API
* @param [in] h GLY_Open�n���h��
* @param [in] EventNumber �C�x���g�ԍ�
* @retval 0 ����I��
* @retval 0�ȊO �G���[�R�[�h
*/
int GLY_DepositFixEvent(GLYHANDLE h, unsigned int EventNumber);

/**
* @brief ���߃C�x���g�f�[�^�ʒm(�����^)
* @param [in] h GLY_Open�n���h��
* @param [in] lppCounters ���߃f�[�^�ւ̃|�C���^
* @retval 0 ����I��
* @retval 0�ȊO �G���[�R�[�h
*/
int GLY_DepositClosing(GLYHANDLE h, LPGLYDEPOSITCOUNTER* lppCounters);

/**
* @brief ���߃C�x���g�f�[�^�ʒm(�񓯊��^)
* @param [in] h GLY_Open�n���h��
* @param [in] lppCounters ���߃f�[�^�ւ̃|�C���^
* @param [in] lpRequestID ���N�G�X�gID
* @retval 0 ����I��
* @retval 0�ȊO �G���[�R�[�h
*/
int GLY_AsyncDepositClosing(GLYHANDLE h, GLYCALLBACK pcb, LPGLYREQUESTID lpRequestID);

/**
* @brief �����@�ʃf�[�^�擾API(�����^)
* @param [in] h GLY_Open�n���h��
* @param [in] lppDEDeviceSettingData �����@�ݒ�f�[�^�ւ̃|�C���^
* @retval 0 ����I��
* @retval 0�ȊO �G���[�R�[�h
*/
int GLY_DE_DeviceSettingDataRequest(GLYHANDLE h, LPGLYDEDEVICESETTINGDATA* lppDEDeviceSettingData);

/**
* @brief �ʉݎ��ʃf�[�^�擾API
* @param [in] h GLY_Open�n���h��
* @param [in] lppDenomination �ʉݎ��ʃf�[�^�ւ̃|�C���^
* @retval 0 ����I��
* @retval 0�ȊO �G���[�R�[�h
*/
int GLY_DE_DenominationDataRequest(GLYHANDLE h, LPGLYDENOMINATION* lppDenomination);

/**
* @brief DE�ŗL���擾API
* @param [in] h GLY_Open�n���h��
* @param [in] lppInformation DE�ŗL���f�[�^�ւ̃|�C���^
* @retval 0 ����I��
* @retval 0�ȊO �G���[�R�[�h
*/
int GLY_DE_InformationRead(GLYHANDLE h, LPGLYDEINFORMATION* lppInformation);

//��2012.10.23 add Ver.0301 �ۑ臂00530 suzuki
/**
* @brief DE ���b�N����
* @param [in] h				GLY_Open�n���h��
* @param [in] pcb			�R�[���o�b�N�֐��ւ̃|�C���^
* @param [in] lpRequestID	���N�G�X�gID
* @param [in] lpprm			AP����̓��̓f�[�^
* @retval 0 ����I��
* @retval 0�ȊO �G���[�R�[�h
*/
int GLY_AsyncDeLock(GLYHANDLE h, GLYCALLBACK pcb, LPGLYREQUESTID lpRequestID, LPGLYLOCK_PARAM* lpprm);
/**
* @brief DE ���b�N����
* @param [in] h		GLY_Open�n���h��
* @param [in] lpprm AP����̓��̓f�[�^
* @retval 0 ����I��
* @retval 0�ȊO �G���[�R�[�h
*/
int GLY_DeLock(GLYHANDLE h, LPGLYLOCK_PARAM* lpprm);
//��2012.10.23 add Ver.0301 �ۑ臂00530 suzuki

//��2012.11.20 add Ver.0301 �ۑ臂00538 suzuki
/**
* @brief DE �A�����b�N����
* @param [in] h GLY_Open�n���h��
* @param [in] pcb �R�[���o�b�N�֐��ւ̃|�C���^
* @param [in] lpRequestID	���N�G�X�gID
* @retval 0 ����I��
* @retval 0�ȊO �G���[�R�[�h
*/
int GLY_AsyncDeUnLock(GLYHANDLE h, GLYCALLBACK pcb, LPGLYREQUESTID lpRequestID);
/**
* @brief DE �A�����b�N����
* @param [in] h		GLY_Open�n���h��
* @retval 0 ����I��
* @retval 0�ȊO �G���[�R�[�h
*/
int GLY_DeUnLock(GLYHANDLE h);
//��2012.11.20 add Ver.0301 �ۑ臂00538 suzuki

//��2012.11.20 add Ver.0301 �ۑ臂00539 suzuki
/**
* @brief DE �v���J�n����
* @param [in] h GLY_Open�n���h��
* @param [in] pcb �R�[���o�b�N�֐��ւ̃|�C���^
* @param [in] lpRequestID	���N�G�X�gID
* @retval 0 ����I��
* @retval 0�ȊO �G���[�R�[�h
*/
int GLY_AsyncDeCntStart(GLYHANDLE h, GLYCALLBACK pcb, LPGLYREQUESTID lpRequestID);
/**
* @brief DE �v���J�n����
* @param [in] h		GLY_Open�n���h��
* @retval 0 ����I��
* @retval 0�ȊO �G���[�R�[�h
*/
int GLY_DeCntStart(GLYHANDLE h, LPGLYDENOMINATION* lppDECounter);
//��2012.11.20 add Ver.0301 �ۑ臂00539 suzuki

//��2012.11.21 add Ver.0301 �ۑ臂00540 suzuki DE�p�v����~����
/**
* @brief DE �v����~����
* @param [in] h		GLY_Open�n���h��
* @retval 0 ����I��
* @retval 0�ȊO �G���[�R�[�h
*/
int GLY_DeCntEnd(GLYHANDLE h);

//��2012.11.22 add Ver.0301 �ۑ臂00542 suzuki
/**
* @brief DE ���[�J�n����
* @param [in] h GLY_Open�n���h��
* @param [in] pcb �R�[���o�b�N�֐��ւ̃|�C���^
* @param [in] lpRequestID	���N�G�X�gID
* @retval 0 ����I��
* @retval 0�ȊO �G���[�R�[�h
*/
int GLY_AsyncDeStore(GLYHANDLE h, GLYCALLBACK pcb, LPGLYREQUESTID lpRequestID);
/**
* @brief DE ���[�J�n����
* @param [in] h		GLY_Open�n���h��
* @retval 0 ����I��
* @retval 0�ȊO �G���[�R�[�h
*/
int GLY_DeStore(GLYHANDLE h);
//��2012.11.22 add Ver.0301 �ۑ臂00542 suzuki

//��2012.11.22 add Ver.0301 �ۑ臂00543 suzuki
/**
* @brief DE �ԋp�J�n����
* @param [in] h GLY_Open�n���h��
* @param [in] pcb �R�[���o�b�N�֐��ւ̃|�C���^
* @param [in] lpRequestID	���N�G�X�gID
* @retval 0 ����I��
* @retval 0�ȊO �G���[�R�[�h
*/
int GLY_AsyncDeCancel(GLYHANDLE h, GLYCALLBACK pcb, LPGLYREQUESTID lpRequestID);
/**
* @brief DE �ԋp�J�n����
* @param [in] h		GLY_Open�n���h��
* @retval 0 ����I��
* @retval 0�ȊO �G���[�R�[�h
*/
int GLY_DeCancel(GLYHANDLE h);
//��2012.11.22 add Ver.0301 �ۑ臂00543 suzuki


//��2012.11.05 add Ver.0301 �ۑ臂00533 suzuki
/**
* @brief DE ���[�h���
* @param [in] h GLY_Open�n���h��
* @param [in] pcb �R�[���o�b�N�֐��ւ̃|�C���^
* @retval 0 ����I��
* @retval 0�ȊO �G���[�R�[�h
*/
int GLY_DeGetMode(GLYHANDLE h, LPGLYMODE* lppDEModeData);

//��2012.11.05 add Ver.030x �ۑ臂00xxx suzuki
/**
* @brief DE ���u���
* @param [in] h GLY_Open�n���h��
* @param [in] pcb �R�[���o�b�N�֐��ւ̃|�C���^
* @retval 0 ����I��
* @retval 0�ȊO �G���[�R�[�h
*/
int GLY_DeGetStatus(GLYHANDLE h, LPGLYMACHINE* lppDEStatusData);

//��2012.11.06 add Ver.0301 �ۑ臂00534 suzuki
/**
* @brief DE �c���E���u���
* @param [in] h GLY_Open�n���h��
* @param [in] pcb �R�[���o�b�N�֐��ւ̃|�C���^
* @retval 0 ����I��
* @retval 0�ȊO �G���[�R�[�h
*/
int GLY_DeGetProperty(GLYHANDLE h, LPGLYDEPROPERTY* lppDEPropertyData);

//��2012.11.07 add Ver.0301 �ۑ臂00535 suzuki
/**
* @brief DE �J�E���g���
* @param [in] h GLY_Open�n���h��
* @param [in] pcb �R�[���o�b�N�֐��ւ̃|�C���^
* @retval 0 ����I��
* @retval 0�ȊO �G���[�R�[�h
*/
//��2012.12.21 upd Ver.0301 �ۑ臂00578 suzuki
//int GLY_DeGetCounter(GLYHANDLE h, LPGLYDECOUNTER* lppDECounterData);
int GLY_DeGetEscrowCounter(GLYHANDLE h, LPGLYDENOMINATION* lppDECounter);

//��2013.03.07 add Ver.0302 �ۑ臂00627 suzuki DE�p����ʔ�
/**
* @brief DE ����ʔ�
* @param [in] h GLY_Open�n���h��
* @param [in] pcb �R�[���o�b�N�֐��ւ̃|�C���^
* @param [in] lpRequestID	���N�G�X�gID
* @retval 0 ����I��
* @retval 0�ȊO �G���[�R�[�h
*/
int GLY_AsyncDeGetTransaction(GLYHANDLE h, GLYCALLBACK hWnd, LPGLYREQUESTID lpRequestID);

/**
* @brief DE ����ʔ�
* @param [in] h GLY_Open�n���h��
* @param [in] pcb �R�[���o�b�N�֐��ւ̃|�C���^
* @retval 0 ����I��
* @retval 0�ȊO �G���[�R�[�h
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
