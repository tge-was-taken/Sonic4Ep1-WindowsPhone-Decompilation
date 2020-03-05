using System;
using System.IO;

// Token: 0x020003E4 RID: 996
internal static class StreamExtensions
{
	// Token: 0x0600288E RID: 10382 RVA: 0x00153470 File Offset: 0x00151670
	public static void CopyTo(this Stream self, Stream dst)
	{
		for (int i = Math.Min((int)self.Length - (int)self.Position, StreamExtensions.buffer.Length); i > 0; i = Math.Min((int)self.Length - (int)self.Position, StreamExtensions.buffer.Length))
		{
			self.Read(StreamExtensions.buffer, 0, i);
			dst.Write(StreamExtensions.buffer, 0, i);
		}
	}

	// Token: 0x040062C7 RID: 25287
	private static byte[] buffer = new byte[16384];
}
