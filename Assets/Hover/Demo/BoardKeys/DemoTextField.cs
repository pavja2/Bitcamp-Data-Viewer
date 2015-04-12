﻿using Hover.Board.Custom.Standard;
using Hover.Board.Display;
using Hover.Common.Display;
using UnityEngine;

namespace Hover.Demo.BoardKeys {

	/*================================================================================================*/
	public class DemoTextField : MonoBehaviour {

		private UiLabel vTextEntry;
		private string vText;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Awake() {
			const int width = 8;

			var lblObj = new GameObject("TextEntry");
			lblObj.transform.SetParent(gameObject.transform, false);
			lblObj.transform.localRotation = Quaternion.FromToRotation(Vector3.down, Vector3.back);
			lblObj.transform.localScale = Vector3.one*0.05f;

			var lblBgObj = GameObject.CreatePrimitive(PrimitiveType.Quad);
			lblBgObj.transform.SetParent(lblObj.transform, false);
			lblBgObj.transform.localPosition = new Vector3(0, 0, 0.01f);
			lblBgObj.transform.localRotation = Quaternion.FromToRotation(Vector3.up, Vector3.back);
			lblBgObj.transform.localScale = new Vector3(width, 1, 1);
			lblBgObj.GetComponent<Renderer>().material = new Material(Shader.Find("Unlit/AlphaSelfIllum"));
			lblBgObj.GetComponent<Renderer>().material.color = new Color(0.1f, 0.1f, 0.1f, 0.666f);
			lblBgObj.GetComponent<Renderer>().material.renderQueue -= 300;

			Color green = HoverboardItemVisualSettingsStandard.Green;
			green.a *= 0.5f;

			vTextEntry = lblObj.AddComponent<UiLabel>();
			vTextEntry.SetSize(width, 1, UiItem.Size*0.012f);
			vTextEntry.FontName = "Tahoma";
			vTextEntry.FontSize = 60;
			vTextEntry.Color = green;
			vTextEntry.Alpha = 1;
			vTextEntry.Label = "";

			ClearLetters();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddLetter(char pLetter) {
			vText += pLetter;
			UpdateLabel();
		}

		/*--------------------------------------------------------------------------------------------*/
		public void RemoveLatestLetter() {
			if ( vText.Length == 0 ) {
				return;
			}

			vText = vText.Substring(0, vText.Length-1);
			UpdateLabel();
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ClearLetters() {
			vText = "";
			UpdateLabel();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void UpdateLabel() {
			vTextEntry.Label = vText+"|";
		}

	}

}
