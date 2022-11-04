using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NovelAIClient.Models
{
    public class GenerationRequest
    {
        public string prompt { get; set; } = "";
        public string? image { get; set; } = null;
        public int n_samples { get; set; } = 1;
        public int steps { get; set; } = 50;
        [JsonConverter(typeof(StringEnumConverter))]
        public Sampling sampler { get; set; } = Sampling.plms;
        public bool fixed_code { get; set; } = false;
        public float ddim_eta { get; set; } = 0.0f;
        public int height { get; set; } = 512;
        public int width { get; set; } = 512;
        public int latent_channels { get; set; } = 4;
        public int downsampling_factor { get; set; } = 8;
        public float scale { get; set; } = 7.0f;
        public float? dynamic_threshold { get; set; } = null;
        public int? seed { get; set; } = null;
        public float temp { get; set; } = 1.0f;
        public int top_k { get; set; } = 256;
        public int grid_size { get; set; } = 4;
        public bool advanced { get; set; } = false;
        public int? stage_two_seed { get; set; } = null;
        public float strength { get; set; } = 0.69f;
        public float noise { get; set; } = 0.667f;
        public bool mitigate { get; set; } = false;
        public string? module { get; set; } = null;
        public IEnumerable<Masker>? masks { get; set; } = null;
        public string? uc { get; set; } = null;
    }
    public class Masker
    {
        public int seed { get; set; }
        public string? mask { get; set; }
    }
    public enum Sampling
    {
        k_euler_ancestral,
        k_euler,
        k_lms,
        plms,
        ddim,
    }
}
