using System.Collections.Generic;

namespace Application.Customizations.HubVeiculos.Helpers
{
    public class TypeExtensions
    {
        public static bool IsVideoExtension(string extension)
        {
            #region Extensions list
            var extensions = new List<string> {
                ".3gp",
                ".3gpp",
                ".3gp",
                ".3g2",
                ".3gp2",
                ".3gp2",
                ".axv",
                ".divx",
                ".mp4",
                ".mp4v",
                ".mp4",
                ".m1v",
                ".m2v",
                ".mod",
                ".mp2",
                ".mp2v",
                ".mpa",
                ".mpe",
                ".mpeg",
                ".mpg",
                ".mpv2",
                ".vbk",
                ".mpg",
                ".ogv",
                ".mov",
                ".mqv",
                ".qt",
                ".mov",
                ".m2t",
                ".m2ts",
                ".mts",
                ".ts",
                ".tts",
                ".m2t",
                ".webm",
                ".dif",
                ".dv",
                ".dv",
                ".flv",
                ".IVF",
                ".lsf",
                ".lsx",
                ".lsf",
                ".m4v",
                ".asf",
                ".asr",
                ".asx",
                ".nsc",
                ".asf",
                ".avi",
                ".wm",
                ".wmp",
                ".wmv",
                ".wmx",
                ".wvx",
                ".movie"
            };
            #endregion
            return extensions.Contains(extension);
        }

        public static bool IsAudioExtension(string extension)
        {
            #region Extensions list
            var extensions = new List<string> {
                ".AAC",
                ".ADTS",
                ".AAC",
                ".ac3",
                ".aif",
                ".aifc",
                ".aiff",
                ".cdda",
                ".aiff",
                ".axa",
                ".aa",
                ".au",
                ".snd",
                ".snd",
                ".flac",
                ".m4a",
                ".m4b",
                ".m4p",
                ".mid",
                ".midi",
                ".rmi",
                ".midi",
                ".mp3",
                ".oga",
                ".ogg",
                ".opus",
                ".spx",
                ".pls",
                ".aax",
                ".ADT",
                ".wav",
                ".wave",
                ".wav",
                ".caf",
                ".gsm",
                ".m4a",
                ".m4r",
                ".m3u",
                ".m3u8",
                ".m3u",
                ".wax",
                ".wma",
                ".ra",
                ".ram",
                ".ra",
                ".rpm",
                ".sd2",
                ".smd",
                ".smx",
                ".smz",
                ".smd"
            };
            #endregion
            return extensions.Contains(extension);
        }

        public static bool IsImageExtension(string extension)
        {
            #region Extensions list
            var extensions = new List<string> {
                ".bmp",
                ".dib",
                ".bmp",
                ".cod",
                ".gif",
                ".ief",
                ".jpe",
                ".jpeg",
                ".jpg",
                ".jpg",
                ".pct",
                ".pic",
                ".pict",
                ".pic",
                ".jfif",
                ".png",
                ".pnz",
                ".png",
                ".svg",
                ".tif",
                ".tiff",
                ".tiff",
                ".wdp",
                ".rf",
                ".wbmp",
                ".webp",
                ".ras",
                ".cmx",
                ".ico",
                ".art",
                ".mac",
                ".pnt",
                ".pntg",
                ".mac",
                ".pnm",
                ".pbm",
                ".pgm",
                ".ppm",
                ".qti",
                ".qtif",
                ".qti",
                ".rgb",
                ".xbm",
                ".xpm",
                ".xwd"
            };
            #endregion
            return extensions.Contains(extension);
        }
    }
}
