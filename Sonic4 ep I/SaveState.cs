using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Threading;
using Microsoft.Xna.Framework.GamerServices;
using Sonic4ep1;

// Token: 0x020003E5 RID: 997
public class SaveState
{
	// Token: 0x06002890 RID: 10384 RVA: 0x001534E8 File Offset: 0x001516E8
	public static void saveCurrentState(int mode)
	{
		if (AppMain.GsTrialIsTrial())
		{
			return;
		}
		SaveState.save.player_pos_x = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)].obj_work.pos.x;
		SaveState.save.player_pos_y = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)].obj_work.pos.y;
		SaveState.save.resume_pos_x = AppMain.g_gm_main_system.resume_pos_x;
		SaveState.save.resume_pos_y = AppMain.g_gm_main_system.resume_pos_y;
		SaveState.save.game_time = AppMain.g_gm_main_system.game_time;
		SaveState.save.time_save = AppMain.g_gm_main_system.time_save;
		SaveState.save.marker_pri = AppMain.g_gm_main_system.marker_pri;
		SaveState.save.water_levell = AppMain.g_gm_main_system.water_level;
		SaveState.save.pseudofall_dir = AppMain.g_gm_main_system.pseudofall_dir;
		SaveState.save.rest_num = AppMain.g_gm_main_system.player_rest_num[0];
		SaveState.save.stage_id = AppMain.g_gs_main_sys_info.stage_id;
		SaveState.save.level = AppMain.g_gs_main_sys_info.level;
		SaveState.save.game_mode = AppMain.g_gs_main_sys_info.game_mode;
		SaveState.save.boss_load_no = AppMain.g_gm_main_system.boss_load_no;
		SaveState.save.player_flag = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)].player_flag;
		SaveState.save.ring_num = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)].ring_num;
		SaveState.save.ring_stage_num = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)].ring_stage_num;
		SaveState.save.score = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)].score;
		if (mode == 1)
		{
			SaveState.save.gm_eve_data = AppMain.gm_eve_data.saveData();
			SaveState.save.gm_ring_data = AppMain.gm_ring_data.saveData();
			SaveState.saveLater = false;
		}
		else
		{
			SaveState.save.gm_eve_data = null;
			SaveState.save.gm_ring_data = null;
			SaveState.saveLater = false;
		}
		if (!SaveState.saveLater)
		{
			if (SaveState.saveThread != null)
			{
				SaveState.saveThread = null;
			}
			SaveState.saveThread = new Thread(new ParameterizedThreadStart(SaveState._saveFile));
			SaveState.SaveData saveData = SaveState.save;
			SaveState.saveThread.Start(saveData);
		}
	}

	// Token: 0x06002891 RID: 10385 RVA: 0x0015373C File Offset: 0x0015193C
	public static void _saveFile(object o)
	{
		SaveState.saveLater = false;
		SaveState.SaveData saveData = (SaveState.SaveData)o;
		if (AppMain.store.FileExists("laststate.dat"))
		{
			AppMain.store.DeleteFile("laststate.dat");
		}
		using (IsolatedStorageFileStream isolatedStorageFileStream = AppMain.store.CreateFile("laststate.dat"))
		{
			saveData.Serialize(isolatedStorageFileStream);
		}
	}

	// Token: 0x06002892 RID: 10386 RVA: 0x001537AC File Offset: 0x001519AC
	public static bool isSaveAvailable()
	{
		if (AppMain.GsTrialIsTrial())
		{
			return false;
		}
		bool result;
		try
		{
			result = AppMain.store.FileExists("laststate.dat");
		}
		catch (Exception)
		{
			result = false;
		}
		return result;
	}

	// Token: 0x06002893 RID: 10387 RVA: 0x001537EC File Offset: 0x001519EC
	public static bool loadState()
	{
		if (AppMain.GsTrialIsTrial())
		{
			return false;
		}
		bool result;
		try
		{
			if (AppMain.store.FileExists("laststate.dat"))
			{
				using (IsolatedStorageFileStream isolatedStorageFileStream = new IsolatedStorageFileStream("laststate.dat", 3, 1, AppMain.store))
				{
					SaveState.save.UnSerialize(isolatedStorageFileStream);
				}
				result = true;
			}
			else
			{
				result = false;
			}
		}
		catch (Exception)
		{
			result = false;
		}
		return result;
	}

	// Token: 0x06002894 RID: 10388 RVA: 0x00153868 File Offset: 0x00151A68
	public static void resumePlayerState()
	{
		if (AppMain.GsTrialIsTrial())
		{
			return;
		}
		AppMain.g_gm_main_system.resume_pos_x = SaveState.save.resume_pos_x;
		AppMain.g_gm_main_system.resume_pos_y = SaveState.save.resume_pos_y;
		AppMain.g_gm_main_system.game_time = SaveState.save.game_time;
		AppMain.g_gm_main_system.time_save = SaveState.save.time_save;
		AppMain.g_gm_main_system.marker_pri = SaveState.save.marker_pri;
		AppMain.g_gm_main_system.water_level = SaveState.save.water_levell;
		AppMain.g_gm_main_system.pseudofall_dir = SaveState.save.pseudofall_dir;
		AppMain.g_gm_main_system.player_rest_num[0] = SaveState.save.rest_num;
		SaveState.resumeStarting = true;
	}

	// Token: 0x06002895 RID: 10389 RVA: 0x00153928 File Offset: 0x00151B28
	public static bool resumePlayer_2(AppMain.GMS_PLAYER_WORK ply_work)
	{
		if (AppMain.GsTrialIsTrial())
		{
			return false;
		}
		SaveState.beginResume = false;
		if (SaveState.resumeStarting)
		{
			ply_work.ring_num = SaveState.save.ring_num;
			ply_work.ring_stage_num = SaveState.save.ring_stage_num;
			ply_work.score = SaveState.save.score;
			ply_work.obj_work.pos.x = SaveState.save.player_pos_x;
			ply_work.obj_work.pos.y = SaveState.save.player_pos_y;
			AppMain.g_gm_main_system.resume_pos_x = SaveState.save.resume_pos_x;
			AppMain.g_gm_main_system.resume_pos_y = SaveState.save.resume_pos_y;
			AppMain.GmCameraPosSet(AppMain.g_gm_main_system.resume_pos_x, AppMain.g_gm_main_system.resume_pos_y, 0);
			AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(AppMain.g_obj.glb_camera_id);
			AppMain.ObjObjectCameraSet(AppMain.FXM_FLOAT_TO_FX32(obs_CAMERA.disp_pos.x - (float)(AppMain.OBD_LCD_X / 2)), AppMain.FXM_FLOAT_TO_FX32(-obs_CAMERA.disp_pos.y - (float)(AppMain.OBD_LCD_Y / 2)), AppMain.FXM_FLOAT_TO_FX32(obs_CAMERA.disp_pos.x - (float)(AppMain.OBD_LCD_X / 2)), AppMain.FXM_FLOAT_TO_FX32(-obs_CAMERA.disp_pos.y - (float)(AppMain.OBD_LCD_Y / 2)));
			AppMain.GmCameraSetClipCamera(obs_CAMERA);
			if ((16384U & SaveState.save.player_flag) != 0U)
			{
				ply_work.obj_work.user_timer = 249856;
				AppMain.gmPlySeqTransformSuperMain(ply_work);
				ply_work.obj_work.user_timer = 0;
				AppMain.gmPlySeqTransformSuperMain(ply_work);
			}
			if (AppMain.g_gm_main_system.boss_load_no == -1)
			{
				int boss_load_no = SaveState.save.boss_load_no;
			}
			SaveState.resumeStarting = false;
			return true;
		}
		return false;
	}

	// Token: 0x06002896 RID: 10390 RVA: 0x00153AD4 File Offset: 0x00151CD4
	public static void resumeStageState()
	{
		if (AppMain.GsTrialIsTrial())
		{
			return;
		}
		AppMain.g_gs_main_sys_info.stage_id = SaveState.save.stage_id;
		AppMain.g_gs_main_sys_info.level = SaveState.save.level;
		AppMain.g_gs_main_sys_info.game_mode = SaveState.save.game_mode;
	}

	// Token: 0x06002897 RID: 10391 RVA: 0x00153B28 File Offset: 0x00151D28
	public static void resumeMapData()
	{
		if (AppMain.GsTrialIsTrial())
		{
			return;
		}
		if (SaveState.save.gm_eve_data != null && SaveState.save.gm_ring_data != null)
		{
			if (SaveState.save.boss_load_no == -1)
			{
				AppMain.gm_eve_data.loadData(SaveState.save.gm_eve_data);
			}
			AppMain.gm_ring_data.loadData(SaveState.save.gm_ring_data);
			return;
		}
		AppMain.g_gs_main_sys_info.game_flag |= 4U;
	}

	// Token: 0x06002898 RID: 10392 RVA: 0x00153BA0 File Offset: 0x00151DA0
	public static void deleteSave()
	{
		if (AppMain.GsTrialIsTrial())
		{
			return;
		}
		SaveState.saveLater = false;
		SaveState.beginResume = false;
		SaveState.save = default(SaveState.SaveData);
		if (AppMain.store.FileExists("laststate.dat"))
		{
			AppMain.store.DeleteFile("laststate.dat");
		}
	}

	// Token: 0x06002899 RID: 10393 RVA: 0x00153BEC File Offset: 0x00151DEC
	public static bool shouldResume()
	{
		return SaveState.beginResume;
	}

	// Token: 0x0600289A RID: 10394 RVA: 0x00153BF4 File Offset: 0x00151DF4
	protected static void GetMBResult(IAsyncResult r)
	{
		try
		{
			if (Guide.EndShowMessageBox(r) == 0 && SaveState.loadState())
			{
				SaveState.beginResume = true;
			}
		}
		finally
		{
			AppMain.g_ao_sys_global.is_show_ui = false;
		}
	}

	// Token: 0x0600289B RID: 10395 RVA: 0x00153C4C File Offset: 0x00151E4C
	public static void showResumeWarning()
	{
		if (SaveState.firstShow)
		{
			SaveState.firstShow = false;
			if (SaveState.isSaveAvailable())
			{
				if (!SaveState.loadState())
				{
					return;
				}
				List<string> list = new List<string>();
				list.Add(Strings.ID_YES);
				list.Add(Strings.ID_NO);
				string id_RESUME_CAPTION = Strings.ID_RESUME_CAPTION;
				string id_RESUME_TEXT = Strings.ID_RESUME_TEXT;
				AppMain.g_ao_sys_global.is_show_ui = true;
				Guide.BeginShowMessageBox(id_RESUME_CAPTION, id_RESUME_TEXT, list, 0, MessageBoxIcon.Warning, new AsyncCallback(SaveState.GetMBResult), null);
			}
		}
	}

	// Token: 0x040062C8 RID: 25288
	public const int SAVE_AFTER_RESPAWN = 0;

	// Token: 0x040062C9 RID: 25289
	public const int SAVE_AFTER_CHECKPOINT = 1;

	// Token: 0x040062CA RID: 25290
	private const string filename = "laststate.dat";

	// Token: 0x040062CB RID: 25291
	public static bool saveLater = false;

	// Token: 0x040062CC RID: 25292
	public static SaveState.SaveData save;

	// Token: 0x040062CD RID: 25293
	private static Thread saveThread;

	// Token: 0x040062CE RID: 25294
	private static bool resumeStarting = false;

	// Token: 0x040062CF RID: 25295
	private static bool beginResume = false;

	// Token: 0x040062D0 RID: 25296
	private static bool firstShow = true;

	// Token: 0x020003E6 RID: 998
	public struct SaveData
	{
		// Token: 0x0600289E RID: 10398 RVA: 0x00153CE4 File Offset: 0x00151EE4
		public void Serialize(Stream stream)
		{
			using (BinaryWriter binaryWriter = new BinaryWriter(stream))
			{
				binaryWriter.Write(0);
				binaryWriter.Write(this.stage_id);
				binaryWriter.Write(this.level);
				binaryWriter.Write(this.game_mode);
				binaryWriter.Write(this.time_save);
				binaryWriter.Write(this.player_pos_x);
				binaryWriter.Write(this.player_pos_y);
				binaryWriter.Write(this.resume_pos_x);
				binaryWriter.Write(this.resume_pos_y);
				binaryWriter.Write(this.marker_pri);
				binaryWriter.Write(this.water_levell);
				binaryWriter.Write(this.pseudofall_dir);
				binaryWriter.Write(this.game_time);
				binaryWriter.Write(this.rest_num);
				binaryWriter.Write(this.boss_load_no);
				binaryWriter.Write(this.player_flag);
				binaryWriter.Write(this.ring_num);
				binaryWriter.Write(this.ring_stage_num);
				binaryWriter.Write(this.score);
				binaryWriter.Write((this.gm_eve_data != null) ? this.gm_eve_data.Length : 0);
				if (this.gm_eve_data != null)
				{
					binaryWriter.Write(this.gm_eve_data);
					binaryWriter.Write(this.gm_ring_data.Length);
					binaryWriter.Write(this.gm_ring_data);
				}
			}
		}

		// Token: 0x0600289F RID: 10399 RVA: 0x00153E48 File Offset: 0x00152048
		public void UnSerialize(Stream stream)
		{
			using (BinaryReader binaryReader = new BinaryReader(stream))
			{
				binaryReader.ReadInt32();
				this.stage_id = binaryReader.ReadUInt16();
				this.level = binaryReader.ReadInt32();
				this.game_mode = binaryReader.ReadInt32();
				this.time_save = binaryReader.ReadUInt32();
				this.player_pos_x = binaryReader.ReadInt32();
				this.player_pos_y = binaryReader.ReadInt32();
				this.resume_pos_x = binaryReader.ReadInt32();
				this.resume_pos_y = binaryReader.ReadInt32();
				this.marker_pri = binaryReader.ReadUInt32();
				this.water_levell = binaryReader.ReadUInt16();
				this.pseudofall_dir = binaryReader.ReadUInt16();
				this.game_time = binaryReader.ReadUInt32();
				this.rest_num = binaryReader.ReadUInt32();
				this.boss_load_no = binaryReader.ReadInt32();
				this.player_flag = binaryReader.ReadUInt32();
				this.ring_num = binaryReader.ReadInt16();
				this.ring_stage_num = binaryReader.ReadInt16();
				this.score = binaryReader.ReadUInt32();
				int num = binaryReader.ReadInt32();
				if (num != 0)
				{
					this.gm_eve_data = binaryReader.ReadBytes(num);
					this.gm_ring_data = binaryReader.ReadBytes(binaryReader.ReadInt32());
				}
			}
		}

		// Token: 0x040062D1 RID: 25297
		public ushort stage_id;

		// Token: 0x040062D2 RID: 25298
		public int level;

		// Token: 0x040062D3 RID: 25299
		public int game_mode;

		// Token: 0x040062D4 RID: 25300
		public uint time_save;

		// Token: 0x040062D5 RID: 25301
		public int player_pos_x;

		// Token: 0x040062D6 RID: 25302
		public int player_pos_y;

		// Token: 0x040062D7 RID: 25303
		public int resume_pos_x;

		// Token: 0x040062D8 RID: 25304
		public int resume_pos_y;

		// Token: 0x040062D9 RID: 25305
		public uint marker_pri;

		// Token: 0x040062DA RID: 25306
		public ushort water_levell;

		// Token: 0x040062DB RID: 25307
		public ushort pseudofall_dir;

		// Token: 0x040062DC RID: 25308
		public uint game_time;

		// Token: 0x040062DD RID: 25309
		public uint rest_num;

		// Token: 0x040062DE RID: 25310
		public int boss_load_no;

		// Token: 0x040062DF RID: 25311
		public uint player_flag;

		// Token: 0x040062E0 RID: 25312
		public short ring_num;

		// Token: 0x040062E1 RID: 25313
		public short ring_stage_num;

		// Token: 0x040062E2 RID: 25314
		public uint score;

		// Token: 0x040062E3 RID: 25315
		public byte[] gm_eve_data;

		// Token: 0x040062E4 RID: 25316
		public byte[] gm_ring_data;
	}
}
