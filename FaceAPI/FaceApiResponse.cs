// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using FaceAPI;
//
//    var data = FaceApiResponse.FromJson(jsonString);
//
namespace FaceAPI
{
    using System;
    using System.Net;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public partial class FaceApiResponse
    {
        [JsonProperty("accessories")]
        public List<Accessory> Accessories { get; set; }

        [JsonProperty("blur")]
        public Blur Blur { get; set; }

        [JsonProperty("emotion")]
        public Emotion Emotion { get; set; }

        [JsonProperty("exposure")]
        public Exposure Exposure { get; set; }

        [JsonProperty("faceAttributes")]
        public FaceAttributes FaceAttributes { get; set; }

        [JsonProperty("faceId")]
        public string FaceId { get; set; }

        [JsonProperty("faceLandmarks")]
        public Dictionary<string, FaceLandmark> FaceLandmarks { get; set; }

        [JsonProperty("faceRectangle")]
        public FaceRectangle FaceRectangle { get; set; }

        [JsonProperty("glasses")]
        public string Glasses { get; set; }

        [JsonProperty("hair")]
        public Hair Hair { get; set; }

        [JsonProperty("headPose")]
        public HeadPose HeadPose { get; set; }

        [JsonProperty("makeup")]
        public Makeup Makeup { get; set; }

        [JsonProperty("noise")]
        public Noise Noise { get; set; }

        [JsonProperty("occlusion")]
        public Occlusion Occlusion { get; set; }
    }

    public partial class Occlusion
    {
        [JsonProperty("eyeOccluded")]
        public bool EyeOccluded { get; set; }

        [JsonProperty("foreheadOccluded")]
        public bool ForeheadOccluded { get; set; }

        [JsonProperty("mouthOccluded")]
        public bool MouthOccluded { get; set; }
    }

    public partial class Noise
    {
        [JsonProperty("noiseLevel")]
        public string NoiseLevel { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }
    }

    public partial class Makeup
    {
        [JsonProperty("eyeMakeup")]
        public bool EyeMakeup { get; set; }

        [JsonProperty("lipMakeup")]
        public bool LipMakeup { get; set; }
    }

    public partial class HeadPose
    {
        [JsonProperty("pitch")]
        public long Pitch { get; set; }

        [JsonProperty("roll")]
        public double Roll { get; set; }

        [JsonProperty("yaw")]
        public long Yaw { get; set; }
    }

    public partial class Hair
    {
        [JsonProperty("bald")]
        public double Bald { get; set; }

        [JsonProperty("hairColor")]
        public List<HairColor> HairColor { get; set; }

        [JsonProperty("invisible")]
        public bool Invisible { get; set; }
    }

    public partial class HairColor
    {
        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }
    }

    public partial class FaceRectangle
    {
        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("left")]
        public long Left { get; set; }

        [JsonProperty("top")]
        public long Top { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }
    }

    public partial class FaceLandmark
    {
        [JsonProperty("x")]
        public double X { get; set; }

        [JsonProperty("y")]
        public double Y { get; set; }
    }

    public partial class FaceAttributes
    {
        [JsonProperty("age")]
        public double Age { get; set; }

        [JsonProperty("facialHair")]
        public FacialHair FacialHair { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("smile")]
        public double Smile { get; set; }
    }

    public partial class FacialHair
    {
        [JsonProperty("beard")]
        public double Beard { get; set; }

        [JsonProperty("moustache")]
        public double Moustache { get; set; }

        [JsonProperty("sideburns")]
        public double Sideburns { get; set; }
    }

    public partial class Exposure
    {
        [JsonProperty("exposureLevel")]
        public string ExposureLevel { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }
    }

    public partial class Emotion
    {
        [JsonProperty("anger")]
        public double Anger { get; set; }

        [JsonProperty("contempt")]
        public long Contempt { get; set; }

        [JsonProperty("disgust")]
        public double Disgust { get; set; }

        [JsonProperty("fear")]
        public double Fear { get; set; }

        [JsonProperty("happiness")]
        public double Happiness { get; set; }

        [JsonProperty("neutral")]
        public double Neutral { get; set; }

        [JsonProperty("sadness")]
        public long Sadness { get; set; }

        [JsonProperty("surprise")]
        public double Surprise { get; set; }
    }

    public partial class Blur
    {
        [JsonProperty("blurLevel")]
        public string BlurLevel { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }
    }

    public partial class Accessory
    {
        [JsonProperty(" confidence")]
        public double? FluffyConfidence { get; set; }

        [JsonProperty("confidence")]
        public double? PurpleConfidence { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class FaceApiResponse
    {
        public static List<FaceApiResponse> FromJson(string json) => JsonConvert.DeserializeObject<List<FaceApiResponse>>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<FaceApiResponse> self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}