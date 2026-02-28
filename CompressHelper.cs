using System;
using System.IO;
using System.IO.Compression;

public static class CompressHelper
{
    public static byte[] GzipCompress(byte[] data)
    {
        if (data == null) throw new ArgumentNullException(nameof(data));
        
        using (var output = new MemoryStream())
        {
            using (var gzip = new GZipStream(output, CompressionMode.Compress))
            {
                gzip.Write(data, 0, data.Length);
            }
            return output.ToArray();
        }
    }

    public static byte[] GzipDecompress(byte[] data)
    {
        if (data == null) throw new ArgumentNullException(nameof(data));
        
        using (var input = new MemoryStream(data))
        using (var gzip = new GZipStream(input, CompressionMode.Decompress))
        using (var output = new MemoryStream())
        {
            gzip.CopyTo(output);
            return output.ToArray();
        }
    }
}
