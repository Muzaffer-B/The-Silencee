using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    //Scene References
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    //Variables
    [SerializeField, Range(0, 365)] private float TimeOfDay;
    public GameObject DayText;
    public Text text;
     GameObject[] StreetLight;
    int day = 1;

    private void Start()
    {

        StreetLight = GameObject.FindGameObjectsWithTag("StreetLight");
    }
    private void Update()
    {
        if (Preset == null)
            return;

        if (Application.isPlaying)
        {
            //(Replace with a reference to the game time)
            TimeOfDay += Time.deltaTime;
            TimeOfDay %= 365; //Modulus to ensure always between 0-24
            UpdateLighting(TimeOfDay / 365f);
            
            
            if(TimeOfDay < 0.005f)
            {
                day++;
                StartCoroutine(daytext());
                text.text = "Day " + day;

                if(day % 5 == 0)
                {
                    
                    StartCoroutine(changetext());
                }
                
            }
            if(TimeOfDay > 280 || TimeOfDay < 71)
            {
                foreach(GameObject g in StreetLight)
                    g.SetActive(true);
                
                
            }
            else
            {

                foreach (GameObject g in StreetLight)
                    g.SetActive(false);
            }
            
        }
        else
        {
            UpdateLighting(TimeOfDay / 365f);
        }
    }


    private void UpdateLighting(float timePercent)
    {
        //Set ambient and fog
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        //If the directional light is set then rotate and set it's color, I actually rarely use the rotation because it casts tall shadows unless you clamp the value
        if (DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);

            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }

    }

    //Try to find a directional light to use if we haven't set one
    private void OnValidate()
    {
        if (DirectionalLight != null)
            return;

        //Search for lighting tab sun
        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        //Search scene for light that fits criteria (directional)
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }
    

    IEnumerator daytext()
    {
        DayText.SetActive(true);
        yield return new WaitForSeconds(3);
        DayText.SetActive(false);
    }
    IEnumerator changetext()
    {
        
        DayText.SetActive(true);
        yield return new WaitForSeconds(3);
        text.text = "village people started to suspect you";
        yield return new WaitForSeconds(3);
        DayText.SetActive(false);
    }
}