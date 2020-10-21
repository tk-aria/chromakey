using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class WebCamSelector : MonoBehaviour
{
	[SerializeField] private Dropdown dropdown;

	public string currentDeviceName;
	private WebCamTexture _webCamTexture;

	[SerializeField] Renderer renderer;
	//[SerializeField] RawImage rawImage;

	[SerializeField] ColorPickerTriangle colorPicker;

    // Start is called before the first frame update
    void Start()
    {
		dropdown.ClearOptions();

		foreach(var device in WebCamTexture.devices)
		{
			var optionData = new Dropdown.OptionData();
			optionData.text = device.name;
			dropdown.options.Add(optionData);
		}

		if (WebCamTexture.devices.Length > 0)
		{
			SetTexture(WebCamTexture.devices[0].name);
		}
	}

	public void DropdownValueChanged(Dropdown change)
	{
		currentDeviceName = change.options[change.value].text;
		SetTexture(currentDeviceName);
	}

	public void SetTexture(string deviceName)
	{
		_webCamTexture = new WebCamTexture(deviceName);
		renderer.material.mainTexture = _webCamTexture;
		//rawImage.texture = _webCamTexture;
		_webCamTexture.Play();
	}

    // Update is called once per frame
    void Update()
    {
		if (colorPicker.gameObject.activeSelf)
		{
			renderer.material.SetColor("" ,colorPicker.TheColor);
		}
    }
}
