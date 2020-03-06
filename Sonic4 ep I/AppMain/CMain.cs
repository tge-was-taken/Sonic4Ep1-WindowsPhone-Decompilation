using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using er;
using accel;
using Microsoft.Xna.Framework.GamerServices;
using mpp;
using System.Collections;

public partial class AppMain
{
	// Token: 0x02000127 RID: 295
	public class CMain : AppMain.CMainTask<AppMain.CMain>
	{
		// Token: 0x06002046 RID: 8262 RVA: 0x0013DD26 File Offset: 0x0013BF26
		public override void operator_brackets()
		{
			if ( this.m_flag[0] )
			{
				this.preUpdate();
			}
			base.operator_brackets();
			if ( this.m_flag[0] )
			{
				this.update();
				this.draw();
			}
		}

		// Token: 0x06002047 RID: 8263 RVA: 0x0013DD5C File Offset: 0x0013BF5C
		public bool Create()
		{
			this.m_flag[0] = true;
			return true;
		}

		// Token: 0x06002048 RID: 8264 RVA: 0x0013DD6C File Offset: 0x0013BF6C
		public void Release()
		{
			if ( this.m_flag[0] )
			{
				if ( this.m_flag[3] )
				{
					for ( int i = 0; i < 2; i++ )
					{
						this.m_file[i] = null;
					}
					this.m_flag[3] = false;
					this.m_flag[4] = false;
				}
				this.m_pTaskLink.DetachTask();
				this.m_flag.SetAll( false );
			}
		}

		// Token: 0x06002049 RID: 8265 RVA: 0x0013DDDB File Offset: 0x0013BFDB
		public void LoadFile()
		{
			this.fileLoadingStart();
		}

		// Token: 0x0600204A RID: 8266 RVA: 0x0013DDE3 File Offset: 0x0013BFE3
		public void CreateTexture()
		{
			this.creatingStart();
		}

		// Token: 0x0600204B RID: 8267 RVA: 0x0013DDEB File Offset: 0x0013BFEB
		public void ReleaseTexture()
		{
			this.releasingStart();
		}

		// Token: 0x0600204C RID: 8268 RVA: 0x0013DDF3 File Offset: 0x0013BFF3
		public void Start( int[] result )
		{
			this.m_result = result;
			this.fadeInStart();
		}

		// Token: 0x0600204D RID: 8269 RVA: 0x0013DE02 File Offset: 0x0013C002
		public bool IsValid()
		{
			return this.m_flag[6];
		}

		// Token: 0x0600204E RID: 8270 RVA: 0x0013DE10 File Offset: 0x0013C010
		public bool IsEmpty()
		{
			return !this.m_flag[0];
		}

		// Token: 0x0600204F RID: 8271 RVA: 0x0013DE21 File Offset: 0x0013C021
		public bool IsLoadFile()
		{
			return this.m_flag[4];
		}

		// Token: 0x06002050 RID: 8272 RVA: 0x0013DE2F File Offset: 0x0013C02F
		public bool IsCreatedTexture()
		{
			return this.m_flag[6];
		}

		// Token: 0x06002051 RID: 8273 RVA: 0x0013DE3D File Offset: 0x0013C03D
		public bool IsReleasedTexture()
		{
			return !this.m_flag[5];
		}

		// Token: 0x06002052 RID: 8274 RVA: 0x0013DE4E File Offset: 0x0013C04E
		public bool IsPlay()
		{
			return !this.m_flag[7];
		}

		// Token: 0x06002054 RID: 8276 RVA: 0x0013DEBC File Offset: 0x0013C0BC
		~CMain()
		{
		}

		// Token: 0x06002055 RID: 8277 RVA: 0x0013DEE4 File Offset: 0x0013C0E4
		private void preUpdate()
		{
			if ( this.m_flag[7] && !this.m_flag[1] )
			{
				for ( int i = 0; i < 2; i++ )
				{
					this.m_trg[i].Update();
				}
			}
		}

		// Token: 0x06002056 RID: 8278 RVA: 0x0013DF28 File Offset: 0x0013C128
		private void update()
		{
			if ( this.m_flag[7] && !this.m_flag[1] )
			{
				for ( int i = 0; i < 2; i++ )
				{
					this.m_trg[i].Update();
				}
			}
		}

		// Token: 0x06002057 RID: 8279 RVA: 0x0013DF6C File Offset: 0x0013C16C
		private void draw()
		{
			if ( AppMain._am_sample_draw_enable && this.m_flag[7] && !this.m_flag[1] )
			{
				for ( int i = 0; i < 9; i++ )
				{
					this.m_act[i].Draw();
				}
			}
		}

		// Token: 0x06002058 RID: 8280 RVA: 0x0013DFB8 File Offset: 0x0013C1B8
		private void fileLoadingStart()
		{
			this.m_fs[0] = AppMain.amFsReadBackground( AppMain.c_global );
			int num = AppMain.GsEnvGetLanguage();
			this.m_fs[1] = AppMain.amFsReadBackground( AppMain.c_lang[num] );
			this.m_flag[3] = true;
			this.m_pTaskLink.AttachTask( "dmBuyScreen::Load", AppMain.c_priority, AppMain.c_user, AppMain.c_attribute );
			base.SetProc( new AppMain.CProc<AppMain.CMain>.FProc( this.fileLoading ) );
		}

		// Token: 0x06002059 RID: 8281 RVA: 0x0013E030 File Offset: 0x0013C230
		public static void fileLoadingS( object pArg )
		{
			AppMain.CMain cmain = (AppMain.CMain)pArg;
			cmain.fileLoading();
		}

		// Token: 0x0600205A RID: 8282 RVA: 0x0013E04C File Offset: 0x0013C24C
		private void fileLoading()
		{
			bool flag = true;
			for ( int i = 0; i < 2; i++ )
			{
				if ( !AppMain.amFsIsComplete( this.m_fs[i] ) )
				{
					flag = false;
					break;
				}
			}
			if ( flag )
			{
				for ( int j = 0; j < 2; j++ )
				{
					this.m_file[j] = this.m_fs[j];
				}
				for ( uint num = 0U; num < 6U; num += 1U )
				{
					AppMain.CMain.SLocalUnfoldTable slocalUnfoldTable = AppMain.CMain.c_local_unfold_table[(int)((UIntPtr)num)];
					int file = (int)slocalUnfoldTable.file;
					int num2 = 2;
					if ( file < num2 )
					{
						string text;
						AppMain.AmbChunk ambChunk = AppMain.amBindGet(this.m_fs[(int)slocalUnfoldTable.file], (int)slocalUnfoldTable.index, out text);
						object obj;
						if ( AppMain.AoActIsAma( ambChunk.array, ambChunk.offset ) )
						{
							obj = AppMain.readAMAFile( ambChunk );
						}
						else
						{
							obj = AppMain.readAMBFile( ambChunk );
						}
						this.m_file[( int )( ( UIntPtr )num )] = obj;
					}
				}
				this.m_flag[4] = true;
				this.m_pTaskLink.DetachTask();
			}
		}

		// Token: 0x0600205B RID: 8283 RVA: 0x0013E130 File Offset: 0x0013C330
		private void creatingStart()
		{
			AppMain.CMain.EFile.EFileEnum[] array = new AppMain.CMain.EFile.EFileEnum[]
			{
				AppMain.CMain.EFile.EFileEnum.GlobalAmb,
				AppMain.CMain.EFile.EFileEnum.LangAmb
			};
			for ( int i = 0; i < 2; i++ )
			{
				AppMain.AoTexBuild( this.m_tex[i], ( AppMain.AMS_AMB_HEADER )this.m_file[( int )array[i]] );
				AppMain.AoTexLoad( this.m_tex[i] );
			}
			this.m_flag[5] = true;
			this.m_pTaskLink.AttachTask( "dmBuyScreen::Build", AppMain.c_priority, AppMain.c_user, AppMain.c_attribute );
			base.SetProc( new AppMain.CProc<AppMain.CMain>.FProc( this.creating ) );
		}

		// Token: 0x0600205C RID: 8284 RVA: 0x0013E1C1 File Offset: 0x0013C3C1
		public static void creatingS( object pArg )
		{
			( ( AppMain.CMain )pArg ).creating();
		}

		// Token: 0x0600205D RID: 8285 RVA: 0x0013E1D0 File Offset: 0x0013C3D0
		public void creating()
		{
			bool flag = true;
			for ( int i = 0; i < 2; i++ )
			{
				if ( !AppMain.AoTexIsLoaded( this.m_tex[i] ) )
				{
					flag = false;
					break;
				}
			}
			if ( flag )
			{
				this.m_flag[6] = true;
				this.m_pTaskLink.DetachTask();
			}
		}

		// Token: 0x0600205E RID: 8286 RVA: 0x0013E21C File Offset: 0x0013C41C
		private void fadeInStart()
		{
			uint num = 0U;
			while ( ( ulong )num < ( ulong )( ( long )AppMain.CMain.c_local_create_action_table.Length ) )
			{
				AppMain.CMain.SLocalCreateActionTable slocalCreateActionTable = AppMain.CMain.c_local_create_action_table[(int)((UIntPtr)num)];
				AppMain.A2S_AMA_HEADER ama = AppMain.readAMAFile(this.m_file[(int)slocalCreateActionTable.file]);
				AppMain.CMain.SAction saction = this.m_act[(int)((UIntPtr)num)];
				saction.act = AppMain.AoActCreate( ama, ( uint )slocalCreateActionTable.idx );
				saction.tex = this.m_tex[( int )( ( UIntPtr )slocalCreateActionTable.tex )];
				saction.flag[0] = true;
				saction.AcmInit();
				num += 1U;
			}
			uint num2 = 0U;
			while ( ( ulong )num2 < ( ulong )( ( long )AppMain.CMain.c_local_create_trg_table.Length ) )
			{
				AppMain.CMain.SAction saction2 = this.m_act[(int)AppMain.CMain.c_local_create_trg_table[(int)((UIntPtr)num2)]];
				CTrgAoAction ctrgAoAction = this.m_trg[(int)((UIntPtr)num2)];
				ctrgAoAction.Create( saction2.act );
				num2 += 1U;
			}
			AppMain.IzFadeInitEasy( 0U, 0U, 30f );
			this.m_flag[7] = true;
			this.m_pTaskLink.AttachTask( "dmBuyScreen::Execute", AppMain.c_priority, AppMain.c_user, AppMain.c_attribute );
			base.SetProc( new AppMain.CProc<AppMain.CMain>.FProc( this.fadeIn ) );
		}

		// Token: 0x0600205F RID: 8287 RVA: 0x0013E333 File Offset: 0x0013C533
		private void fadeIn()
		{
			if ( AppMain.IzFadeIsEnd() )
			{
				AppMain.IzFadeExit();
				this.waitStart();
			}
		}

		// Token: 0x06002060 RID: 8288 RVA: 0x0013E347 File Offset: 0x0013C547
		private void waitStart()
		{
			base.SetProc( new AppMain.CProc<AppMain.CMain>.FProc( this.wait ) );
		}

		// Token: 0x06002061 RID: 8289 RVA: 0x0013E35C File Offset: 0x0013C55C
		private void wait()
		{
			bool flag = false;
			int i = 0;
			int num = AppMain._am_tp_touch.Length;
			while ( i < num )
			{
				if ( AppMain.amTpIsTouchOn( i ) )
				{
					flag = true;
					break;
				}
				i++;
			}
			if ( !flag || 60UL < base.GetCount() )
			{
				this.selectStart();
			}
		}

		// Token: 0x06002062 RID: 8290 RVA: 0x0013E39F File Offset: 0x0013C59F
		private void selectStart()
		{
			base.SetProc( new AppMain.CProc<AppMain.CMain>.FProc( this.select ) );
		}

		// Token: 0x06002063 RID: 8291 RVA: 0x0013E3B4 File Offset: 0x0013C5B4
		private void select()
		{
			int num = -1;
			for ( int i = 0; i < 2; i++ )
			{
				CTrgAoAction ctrgAoAction = this.m_trg[i];
				float frame;
				if ( ctrgAoAction.GetState( 0U )[10] && ctrgAoAction.GetState( 0U )[1] )
				{
					frame = 1f;
					num = i;
				}
				else if ( ctrgAoAction.GetState( 0U )[0] )
				{
					frame = 2f;
				}
				else
				{
					frame = 0f;
				}
				uint num2 = 0U;
				while ( ( ulong )num2 < ( ulong )( ( long )AppMain.arrayof( AppMain.CMain.c_btn_action_table[i] ) ) )
				{
					AppMain.CMain.EAct.Type[] array = AppMain.CMain.c_btn_action_table[i];
					AppMain.AoActSetFrame( this.m_act[( int )array[( int )( ( UIntPtr )num2 )]].act, frame );
					num2 += 1U;
				}
			}
			if ( -1 != num )
			{
				AppMain.CMain.EAct.Type[] array2 = AppMain.CMain.c_btn_action_table[num];
				for ( int j = ( int )array2[0]; j < ( int )( array2[2] + 1 ); j++ )
				{
					this.m_act[j].flag[0] = false;
				}
				AppMain.DmSoundPlaySE( "Ok" );
				this.m_result[0] = AppMain.CMain.TrgIdxToReturnIdx( num );
				this.enterEfctStart();
			}
		}

		// Token: 0x06002064 RID: 8292 RVA: 0x0013E4B6 File Offset: 0x0013C6B6
		private void enterEfctStart()
		{
			base.SetProc( new AppMain.CProc<AppMain.CMain>.FProc( this.enterEfct ) );
		}

		// Token: 0x06002065 RID: 8293 RVA: 0x0013E4CA File Offset: 0x0013C6CA
		private void enterEfct()
		{
			if ( 30UL < base.GetCount() )
			{
				if ( this.m_result[0] == 0 )
				{
					XBOXLive.showGuide();
					if ( !Guide.IsVisible )
					{
						XBOXLive.isTrial( true );
						this.fadeOutStart();
						return;
					}
				}
				else
				{
					this.fadeOutStart();
				}
			}
		}

		// Token: 0x06002066 RID: 8294 RVA: 0x0013E501 File Offset: 0x0013C701
		private void fadeOutStart()
		{
			AppMain.IzFadeInitEasy( 0U, 1U, 30f );
			base.SetProc( new AppMain.CProc<AppMain.CMain>.FProc( this.fadeOut ) );
		}

		// Token: 0x06002067 RID: 8295 RVA: 0x0013E524 File Offset: 0x0013C724
		private void fadeOut()
		{
			if ( AppMain.IzFadeIsEnd() )
			{
				for ( int i = 0; i < 9; i++ )
				{
					AppMain.AoActDelete( this.m_act[i].act );
				}
				this.m_flag[7] = false;
				this.m_pTaskLink.DetachTask();
			}
		}

		// Token: 0x06002068 RID: 8296 RVA: 0x0013E570 File Offset: 0x0013C770
		private void releasingStart()
		{
			for ( int i = 0; i < 2; i++ )
			{
				AppMain.AoTexRelease( this.m_tex[i] );
			}
			this.m_pTaskLink.AttachTask( "dmBuyScreen::Flush", AppMain.c_priority, AppMain.c_user, AppMain.c_attribute );
			base.SetProc( new AppMain.CProc<AppMain.CMain>.FProc( this.releasing ) );
		}

		// Token: 0x06002069 RID: 8297 RVA: 0x0013E5C7 File Offset: 0x0013C7C7
		public static void releasingS( object pArg )
		{
			( ( AppMain.CMain )pArg ).releasing();
		}

		// Token: 0x0600206A RID: 8298 RVA: 0x0013E5D4 File Offset: 0x0013C7D4
		private void releasing()
		{
			bool flag = true;
			for ( int i = 0; i < 2; i++ )
			{
				if ( !AppMain.AoTexIsReleased( this.m_tex[i] ) )
				{
					flag = false;
					break;
				}
			}
			if ( flag )
			{
				this.m_flag[5] = false;
				this.m_flag[6] = false;
				this.m_pTaskLink.DetachTask();
			}
		}

		// Token: 0x0600206B RID: 8299 RVA: 0x0013E62C File Offset: 0x0013C82C
		private static int TrgIdxToReturnIdx( int trg_idx )
		{
			return AppMain.CMain.c_return_table[trg_idx];
		}

		// Token: 0x04004CAD RID: 19629
		public static readonly int[] c_return_table = new int[]
		{
			default(int),
			1
		};

		// Token: 0x04004CAE RID: 19630
		private BitArray m_flag = new BitArray(8);

		// Token: 0x04004CAF RID: 19631
		private int[] m_result;

		// Token: 0x04004CB0 RID: 19632
		private readonly AppMain.AMS_FS[] m_fs = new AppMain.AMS_FS[2];

		// Token: 0x04004CB1 RID: 19633
		private readonly object[] m_file = new object[6];

		// Token: 0x04004CB2 RID: 19634
		private AppMain.AOS_TEXTURE[] m_tex = AppMain.New<AppMain.AOS_TEXTURE>(2);

		// Token: 0x04004CB3 RID: 19635
		private AppMain.CMain.SAction[] m_act = AppMain.New<AppMain.CMain.SAction>(9);

		// Token: 0x04004CB4 RID: 19636
		private CTrgAoAction[] m_trg = AppMain.New<CTrgAoAction>(2);

		// Token: 0x04004CB5 RID: 19637
		private static AppMain.CMain.SLocalUnfoldTable[] c_local_unfold_table = new AppMain.CMain.SLocalUnfoldTable[]
		{
			new AppMain.CMain.SLocalUnfoldTable(AppMain.CMain.EMemFile.Type.None, 0U),
			new AppMain.CMain.SLocalUnfoldTable(AppMain.CMain.EMemFile.Type.None, 0U),
			new AppMain.CMain.SLocalUnfoldTable(AppMain.CMain.EMemFile.Type.Global, 0U),
			new AppMain.CMain.SLocalUnfoldTable(AppMain.CMain.EMemFile.Type.Global, 1U),
			new AppMain.CMain.SLocalUnfoldTable(AppMain.CMain.EMemFile.Type.Lang, 0U),
			new AppMain.CMain.SLocalUnfoldTable(AppMain.CMain.EMemFile.Type.Lang, 1U)
		};

		// Token: 0x04004CB6 RID: 19638
		public static readonly AppMain.CMain.SLocalCreateActionTable[] c_local_create_action_table = new AppMain.CMain.SLocalCreateActionTable[]
		{
			new AppMain.CMain.SLocalCreateActionTable(AppMain.CMain.EFile.EFileEnum.LangAma, AppMain.CMain.ETex.Type.Lang, 0),
			new AppMain.CMain.SLocalCreateActionTable(AppMain.CMain.EFile.EFileEnum.GlobalAma, AppMain.CMain.ETex.Type.Global, 0),
			new AppMain.CMain.SLocalCreateActionTable(AppMain.CMain.EFile.EFileEnum.GlobalAma, AppMain.CMain.ETex.Type.Global, 1),
			new AppMain.CMain.SLocalCreateActionTable(AppMain.CMain.EFile.EFileEnum.GlobalAma, AppMain.CMain.ETex.Type.Global, 2),
			new AppMain.CMain.SLocalCreateActionTable(AppMain.CMain.EFile.EFileEnum.GlobalAma, AppMain.CMain.ETex.Type.Global, 3),
			new AppMain.CMain.SLocalCreateActionTable(AppMain.CMain.EFile.EFileEnum.GlobalAma, AppMain.CMain.ETex.Type.Global, 4),
			new AppMain.CMain.SLocalCreateActionTable(AppMain.CMain.EFile.EFileEnum.GlobalAma, AppMain.CMain.ETex.Type.Global, 5),
			new AppMain.CMain.SLocalCreateActionTable(AppMain.CMain.EFile.EFileEnum.LangAma, AppMain.CMain.ETex.Type.Lang, 1),
			new AppMain.CMain.SLocalCreateActionTable(AppMain.CMain.EFile.EFileEnum.LangAma, AppMain.CMain.ETex.Type.Lang, 2)
		};

		// Token: 0x04004CB7 RID: 19639
		public static readonly AppMain.CMain.EAct.Type[] c_local_create_trg_table = new AppMain.CMain.EAct.Type[]
		{
			AppMain.CMain.EAct.Type.BuyCenter,
			AppMain.CMain.EAct.Type.CancelCenter
		};

		// Token: 0x04004CB8 RID: 19640
		public static readonly AppMain.CMain.EAct.Type[][] c_btn_action_table = new AppMain.CMain.EAct.Type[][]
		{
			new AppMain.CMain.EAct.Type[]
			{
				AppMain.CMain.EAct.Type.BuyLeft,
				AppMain.CMain.EAct.Type.BuyCenter,
				AppMain.CMain.EAct.Type.BuyRight
			},
			new AppMain.CMain.EAct.Type[]
			{
				AppMain.CMain.EAct.Type.CancelLeft,
				AppMain.CMain.EAct.Type.CancelCenter,
				AppMain.CMain.EAct.Type.CancelRight
			}
		};

		// Token: 0x02000128 RID: 296
		private class BFlag
		{
			// Token: 0x02000129 RID: 297
			public enum EFlag
			{
				// Token: 0x04004CBA RID: 19642
				Create,
				// Token: 0x04004CBB RID: 19643
				NoUpdate,
				// Token: 0x04004CBC RID: 19644
				NoDraw,
				// Token: 0x04004CBD RID: 19645
				LoadFile,
				// Token: 0x04004CBE RID: 19646
				LoadedFile,
				// Token: 0x04004CBF RID: 19647
				CreateTexture,
				// Token: 0x04004CC0 RID: 19648
				CreatedTexture,
				// Token: 0x04004CC1 RID: 19649
				Start,
				// Token: 0x04004CC2 RID: 19650
				Max,
				// Token: 0x04004CC3 RID: 19651
				None
			}
		}

		// Token: 0x0200012A RID: 298
		public class EMemFile
		{
			// Token: 0x0200012B RID: 299
			public enum Type
			{
				// Token: 0x04004CC5 RID: 19653
				Global,
				// Token: 0x04004CC6 RID: 19654
				Lang,
				// Token: 0x04004CC7 RID: 19655
				Max,
				// Token: 0x04004CC8 RID: 19656
				None
			}
		}

		// Token: 0x0200012C RID: 300
		public class EFile : AppMain.CMain.EMemFile
		{
			// Token: 0x0200012D RID: 301
			public enum EFileEnum
			{
				// Token: 0x04004CCA RID: 19658
				GlobalAma = 2,
				// Token: 0x04004CCB RID: 19659
				GlobalAmb,
				// Token: 0x04004CCC RID: 19660
				LangAma,
				// Token: 0x04004CCD RID: 19661
				LangAmb,
				// Token: 0x04004CCE RID: 19662
				Max,
				// Token: 0x04004CCF RID: 19663
				None
			}
		}

		// Token: 0x0200012E RID: 302
		public class ETex
		{
			// Token: 0x0200012F RID: 303
			public enum Type
			{
				// Token: 0x04004CD1 RID: 19665
				Global,
				// Token: 0x04004CD2 RID: 19666
				Lang,
				// Token: 0x04004CD3 RID: 19667
				Max,
				// Token: 0x04004CD4 RID: 19668
				None
			}
		}

		// Token: 0x02000130 RID: 304
		public class EAct
		{
			// Token: 0x02000131 RID: 305
			public enum Type
			{
				// Token: 0x04004CD6 RID: 19670
				Bgi,
				// Token: 0x04004CD7 RID: 19671
				BuyLeft,
				// Token: 0x04004CD8 RID: 19672
				BuyCenter,
				// Token: 0x04004CD9 RID: 19673
				BuyRight,
				// Token: 0x04004CDA RID: 19674
				CancelLeft,
				// Token: 0x04004CDB RID: 19675
				CancelCenter,
				// Token: 0x04004CDC RID: 19676
				CancelRight,
				// Token: 0x04004CDD RID: 19677
				Buy,
				// Token: 0x04004CDE RID: 19678
				Cancel,
				// Token: 0x04004CDF RID: 19679
				Max,
				// Token: 0x04004CE0 RID: 19680
				None
			}
		}

		// Token: 0x02000132 RID: 306
		private class ETrg
		{
			// Token: 0x02000133 RID: 307
			public enum Type
			{
				// Token: 0x04004CE2 RID: 19682
				Buy,
				// Token: 0x04004CE3 RID: 19683
				Cancel,
				// Token: 0x04004CE4 RID: 19684
				Max,
				// Token: 0x04004CE5 RID: 19685
				None
			}
		}

		// Token: 0x02000134 RID: 308
		public class SAction
		{
			// Token: 0x06002073 RID: 8307 RVA: 0x0013E7FC File Offset: 0x0013C9FC
			public void AcmInit()
			{
				this.pos = CArray3<float>.initializer( 0f, 0f, 0f );
				this.scale = CArray2<float>.initializer( 1f, 1f );
				this.color.c = uint.MaxValue;
				this.act.sprite.texlist = this.tex.texlist;
			}

			// Token: 0x06002074 RID: 8308 RVA: 0x0013E860 File Offset: 0x0013CA60
			public void Update()
			{
				AppMain.AoActAcmPush();
				float frame = this.flag[0] ? 0f : 1f;
				AppMain.AoActSetTexture( AppMain.AoTexGetTexList( this.tex ) );
				if ( !CArray2<float>.initializer( 1f, 1f ).equals( this.scale ) )
				{
					AppMain.AoActAcmApplyScale( this.scale.x, this.scale.y );
				}
				if ( !CArray3<float>.initializer( 0f, 0f, 0f ).equals( this.pos ) )
				{
					AppMain.AoActAcmApplyTrans( this.pos.x, this.pos.y, this.pos.z );
				}
				if ( 4294967295U != this.color.c )
				{
					AppMain.AoActAcmApplyColor( this.color );
				}
				AppMain.AoActUpdate( this.act, frame );
				AppMain.AoActAcmPop();
			}

			// Token: 0x06002075 RID: 8309 RVA: 0x0013E947 File Offset: 0x0013CB47
			public void Draw()
			{
				if ( this.flag[1] )
				{
					return;
				}
				if ( this.flag[2] )
				{
					AppMain.AoActSortRegAction( this.act );
					return;
				}
				AppMain.AoActDraw( this.act );
			}

			// Token: 0x04004CE6 RID: 19686
			public AppMain.AOS_ACTION act;

			// Token: 0x04004CE7 RID: 19687
			public AppMain.AOS_TEXTURE tex;

			// Token: 0x04004CE8 RID: 19688
			public bool[] flag = new bool[3];

			// Token: 0x04004CE9 RID: 19689
			public CArray2<float> scale;

			// Token: 0x04004CEA RID: 19690
			public CArray3<float> pos;

			// Token: 0x04004CEB RID: 19691
			public AppMain.AOS_ACT_COL color;

			// Token: 0x02000135 RID: 309
			public class BFlag
			{
				// Token: 0x02000136 RID: 310
				public enum ESAction
				{
					// Token: 0x04004CED RID: 19693
					NoUpdate,
					// Token: 0x04004CEE RID: 19694
					NoDraw,
					// Token: 0x04004CEF RID: 19695
					SortDraw,
					// Token: 0x04004CF0 RID: 19696
					Max,
					// Token: 0x04004CF1 RID: 19697
					None
				}
			}
		}

		// Token: 0x02000137 RID: 311
		private class SLocalUnfoldTable
		{
			// Token: 0x06002078 RID: 8312 RVA: 0x0013E991 File Offset: 0x0013CB91
			public SLocalUnfoldTable( AppMain.CMain.EMemFile.Type type, uint _index )
			{
				this.file = type;
				this.index = _index;
			}

			// Token: 0x04004CF2 RID: 19698
			public AppMain.CMain.EMemFile.Type file;

			// Token: 0x04004CF3 RID: 19699
			public uint index;
		}

		// Token: 0x02000138 RID: 312
		public struct SLocalCreateActionTable
		{
			// Token: 0x06002079 RID: 8313 RVA: 0x0013E9A7 File Offset: 0x0013CBA7
			public SLocalCreateActionTable( AppMain.CMain.EFile.EFileEnum file, AppMain.CMain.ETex.Type tex, int idx )
			{
				this.file = file;
				this.tex = tex;
				this.idx = idx;
			}

			// Token: 0x04004CF4 RID: 19700
			public AppMain.CMain.EFile.EFileEnum file;

			// Token: 0x04004CF5 RID: 19701
			public AppMain.CMain.ETex.Type tex;

			// Token: 0x04004CF6 RID: 19702
			public int idx;
		}
	}
}
