using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace NovelAIClient.Models
{
    /// <summary>
    /// WebUI请求参数实体类
    /// </summary>
    public class WebUIRequestModel
    {
        /// <summary>
        /// Prompt
        /// </summary>
        public string Prompt { get; set; } = "";
        /// <summary>
        /// Negative prompt
        /// </summary>
        public string NegativePrompt { get; set; } = "";
        public string Param2 { get; set; } = "None";
        public string Param3 { get; set; } = "None";
        /// <summary>
        /// Sampling Steps
        /// </summary>
        public int SamplingSteps { get; set; } = 20;
        /// <summary>
        /// Sampling Method
        /// </summary>
        public SamplingMethods SamplingMethod { get; set; } = SamplingMethods.Euler_a;  //Sampling method ("Euler a","Euler","LMS","Heun","DPM2","DPM2 a","DPM fast","DPM adaptive","LMS Karras","DPM2 Karras","DPM2 a Karras","DDIM","PLMS")
        public bool Param6 { get; set; } = false;
        public bool Param7 { get; set; } = false;
        /// <summary>
        /// Batch count
        /// </summary>
        public int BatchCount { get; set; } = 1;
        /// <summary>
        /// Batch size
        /// </summary>
        public int BatchSize { get; set; } = 1;
        /// <summary>
        /// CFG Scale
        /// </summary>
        public int CFGScale { get; set; } = 7;
        /// <summary>
        /// Seed   (Set seed to -1, which will cause a new random number to be used every time)
        /// </summary>
        public int Seed { get; set; } = -1;
        /// <summary>
        /// Variation seed
        /// </summary>
        public int VariationSeed { get; set; } = -1;
        /// <summary>
        /// Variation strength
        /// </summary>
        public int VariationStrength { get; set; } = 0;
        /// <summary>
        /// Resize seed from height
        /// </summary>
        public int ResizeSeedFromHeight { get; set; } = 0;
        /// <summary>
        /// Resize seed from width
        /// </summary>
        public int ResizeSeedFromWidth { get; set; } = 0;
        public bool Param16 { get; set; } = false;
        /// <summary>
        /// Height
        /// </summary>
        public int Height { get; set; } = 512;
        /// <summary>
        /// Width
        /// </summary>
        public int Width { get; set; } = 512;
        public bool Param19 { get; set; } = false;
        public float Param20 { get; set; } = 0.7f;
        public int Param21 { get; set; } = 0;
        public int Param22 { get; set; } = 0;
        /// <summary>
        /// Script
        /// </summary>
        public Scripts Script { get; set; } = Scripts.None;
        /// <summary>
        /// Put variable parts at start of prompt
        /// </summary>
        public bool PutVariablePartsAtStartOfPrompt { get; set; } = false;
        /// <summary>
        /// Show Textbox
        /// </summary>
        public bool ShowTextbox { get; set; } = false;
        /// <summary>
        /// Prompts File
        /// </summary>
        public PromptsFile? promptsFile { get; set; } = null;
        /// <summary>
        /// Prompts
        /// </summary>
        public string Prompts { get; set; } = "";
        /// <summary>
        /// X type
        /// </summary>
        public XYType XType { get; set; } = XYType.Seed;
        /// <summary>
        /// X values
        /// </summary>
        public string XValues { get; set; } = "";
        /// <summary>
        /// Y type
        /// </summary>
        public XYType YType { get; set; } = XYType.Nothing;
        /// <summary>
        /// Y values
        /// </summary>
        public string YValues { get; set; } = "";
        /// <summary>
        /// Draw legend
        /// </summary>
        public bool DrawLegend { get; set; } = true;
        /// <summary>
        /// Include Separate Images
        /// </summary>
        public bool IncludeSeparateImages { get; set; } = false;
        /// <summary>
        /// Keep -1 for seeds
        /// </summary>
        public bool Keep__1_for_seeds { get; set; } = false;
        public object? Param35 { get; set; } = null;

        public ArrayList ToArray()
        {
            ArrayList array = new ArrayList();
            PropertyInfo[] props = GetType().GetProperties();
            for (int i = 0; i < props.Length; i++)
            {
                object? val = props[i].GetValue(this);
                if (val != null)
                {
                    Type type = val.GetType();
                    if (type.IsEnum)
                    {
                        FieldInfo field = type.GetField(val.ToString()!)!;
                        DisplayAttribute display = field.GetCustomAttribute<DisplayAttribute>()!;
                        array.Add(display.Name);
                    }
                    else
                    {
                        array.Add(val);
                    }
                }
                else
                {
                    array.Add(null);
                }
            }
            return array;
        }
    }

    public enum XYType
    {
        [Display(Name = "Nothing")]
        Nothing,
        [Display(Name = "Seed")]
        Seed,
        [Display(Name = "Var. seed")]
        Var_seed,
        [Display(Name = "Var. strength")]
        Var_strength,
        [Display(Name = "Steps")]
        Steps,
        [Display(Name = "CFG Scale")]
        CFG_Scale,
        [Display(Name = "Prompt S/R")]
        Prompt_S_R,
        [Display(Name = "Prompt order")]
        Prompt_order,
        [Display(Name = "Sampler")]
        Sampler,
        [Display(Name = "Checkpoint name")]
        Checkpoint_name,
        [Display(Name = "Hypernetwork")]
        Hypernetwork,
        [Display(Name = "Hypernet str.")]
        Hypernet_str,
        [Display(Name = "Sigma Churn")]
        Sigma_Churn,
        [Display(Name = "Sigma min")]
        Sigma_min,
        [Display(Name = "Sigma max")]
        Sigma_max,
        [Display(Name = "Sigma noise")]
        Sigma_noise,
        [Display(Name = "Eta")]
        Eta,
        [Display(Name = "Clip skip")]
        Clip_skip,
        [Display(Name = "Denoising")]
        Denoising,
    }

    public enum Scripts
    {
        [Display(Name = "None")]
        None,
        [Display(Name = "Prompt matrix")]
        Prompt_matrix,
        [Display(Name = "Prompts from file or textbox")]
        Prompts_from_file_or_textbox,
        [Display(Name = "X/Y plot")]
        X_Y_plot,
    }

    public enum SamplingMethods
    {
        [Display(Name = "Euler a")]
        Euler_a,
        [Display(Name = "Euler")]
        Euler,
        [Display(Name = "LMS")]
        LMS,
        [Display(Name = "Heun")]
        Heun,
        [Display(Name = "DPM2")]
        DPM2,
        [Display(Name = "DPM2 a")]
        DPM2_a,
        [Display(Name = "DPM fast")]
        DPM_fast,
        [Display(Name = "DPM adaptive")]
        DPM_adaptive,
        [Display(Name = "LMS Karras")]
        LMS_Karras,
        [Display(Name = "DPM2 Karras")]
        DPM2_Karras,
        [Display(Name = "DPM2 a Karras")]
        DPM2_a_Karras,
        [Display(Name = "DDIM")]
        DDIM,
        [Display(Name = "PLMS")]
        PLMS,
    }

    public class PromptsFile
    {
        /// <summary>
        /// File Name
        /// </summary>
        public string? name { get; set; }
        /// <summary>
        /// Text Length
        /// </summary>
        public int size { get; set; }
        /// <summary>
        /// Data Base64
        /// </summary>
        public string data { get; set; } = "data:text/plain;base64,";
    }
}
