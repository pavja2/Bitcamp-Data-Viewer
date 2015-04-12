using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using UnityEngine.EventSystems;  

public class DataMapper : MonoBehaviour
{
	
	// Use this for initialization
	void Start (){
		renderPopulationHighSchoolDegree (loadPopulation ());
	}
	
	// Update is called once per frame
	void Update (){
		
	}
	
	/****************************************************
 * 													*
 * 													*
 * 				    CRIME DATA						*
 * 													*
 * 													*
 ****************************************************/
	
	public class CrimeEntry {
		public string shift;
		public string offense;
		public string method;
		public string ward;
		public string district;
		public string reportDate;
	}
	
	public static List<CrimeEntry> loadCrimes (){
		resetBars ();
		Dictionary<string, int> myObjectMap = new Dictionary<string, int> ();
		List<CrimeEntry> crimeList = new List<CrimeEntry> ();
		using (CsvReader csv = new CsvReader(new StreamReader("data.csv"), true)) {
			int fieldCount = csv.FieldCount;
			string[] headers = csv.GetFieldHeaders ();
			
			for (int i = 0; i < fieldCount; i++) {
				myObjectMap [headers [i]] = i;
			}
			while (csv.ReadNextRecord()) {
				CrimeEntry crime = new CrimeEntry ();
				
				crime.shift = csv [myObjectMap ["SHIFT"]];
				crime.offense = csv [myObjectMap ["OFFENSE"]];
				crime.method = csv [myObjectMap ["METHOD"]];
				crime.ward = csv [myObjectMap ["WARD"]];
				crime.district = csv [myObjectMap ["DISTRICT"]];
				crime.reportDate = csv [myObjectMap ["REPORTDATETIME"]];
				crimeList.Add (crime);
			}
		}
		return crimeList;
	}
	
	public static void renderCrimesTotal(List<CrimeEntry> crimes){
		int ward1Count = 0, ward2Count = 0, ward3Count = 0, 
		ward4Count = 0, ward5Count = 0, ward6Count = 0, 
		ward7Count = 0, ward8Count = 0;
		int totalCount = 0;
		
		foreach (CrimeEntry crime in crimes) {
			switch (crime.ward) {
			case "1":
				ward1Count++;
				break;
			case "2":
				ward2Count++;
				break;
			case "3":
				ward3Count++;
				break;
			case "4":
				ward4Count++;
				break;
			case "5":
				ward5Count++;
				break;
			case "6":
				ward6Count++;
				break;
			case "7":
				ward7Count++;
				break;
			case "8":
				ward8Count++;
				break;
			default:
				break;
			}
			totalCount++;
		}
		
		Hashtable w1Scale = new Hashtable ();
		w1Scale.Add ("y", -1.5+4*(double)ward1Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward1"), w1Scale);
		
		Hashtable w2Scale = new Hashtable ();
		w2Scale.Add ("y", -1.5+4*(double)ward2Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward2"), w2Scale);
		
		Hashtable w3Scale = new Hashtable ();
		w3Scale.Add ("y", -1.5+4*(double)ward3Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward3"), w3Scale);
		
		Hashtable w4Scale = new Hashtable ();
		w4Scale.Add ("y", -1.5+4*(double)ward4Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward4"), w4Scale);
		
		Hashtable w5Scale = new Hashtable ();
		w5Scale.Add ("y", -1.5+4*(double)ward5Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward5"), w5Scale);
		
		Hashtable w6Scale = new Hashtable ();
		w6Scale.Add ("y", -1.5+4*(double)ward6Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward6"), w6Scale);
		
		Hashtable w7Scale = new Hashtable ();
		w7Scale.Add ("y", -1.5+4*(double)ward7Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward7"), w7Scale);
		
		Hashtable w8Scale = new Hashtable ();
		w8Scale.Add ("y", -1.5+4*(double)ward8Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward8"), w8Scale);
	}
	
	public static void renderCrimesShift(List<CrimeEntry> crimes, string shift) {
		int ward1Count = 0, ward2Count = 0, ward3Count = 0, 
		ward4Count = 0, ward5Count = 0, ward6Count = 0, 
		ward7Count = 0, ward8Count = 0;
		int totalCount = 0;
		
		foreach (CrimeEntry crime in crimes) {
			if (crime.shift == shift) {
				switch (crime.ward) {
				case "1":
					ward1Count++;
					break;
				case "2":
					ward2Count++;
					break;
				case "3":
					ward3Count++;
					break;
				case "4":
					ward4Count++;
					break;
				case "5":
					ward5Count++;
					break;
				case "6":
					ward6Count++;
					break;
				case "7":
					ward7Count++;
					break;
				case "8":
					ward8Count++;
					break;
				default:
					break;
				}
				totalCount++;
			}
		}
		Hashtable w1Scale = new Hashtable ();
		w1Scale.Add ("y", -1.5+4*(double)ward1Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward1"), w1Scale);
		
		Hashtable w2Scale = new Hashtable ();
		w2Scale.Add ("y", -1.5+4*(double)ward2Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward2"), w2Scale);
		
		Hashtable w3Scale = new Hashtable ();
		w3Scale.Add ("y", -1.5+4*(double)ward3Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward3"), w3Scale);
		
		Hashtable w4Scale = new Hashtable ();
		w4Scale.Add ("y", -1.5+4*(double)ward4Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward4"), w4Scale);
		
		Hashtable w5Scale = new Hashtable ();
		w5Scale.Add ("y", -1.5+4*(double)ward5Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward5"), w5Scale);
		
		Hashtable w6Scale = new Hashtable ();
		w6Scale.Add ("y", -1.5+4*(double)ward6Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward6"), w6Scale);
		
		Hashtable w7Scale = new Hashtable ();
		w7Scale.Add ("y", -1.5+4*(double)ward7Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward7"), w7Scale);
		
		Hashtable w8Scale = new Hashtable ();
		w8Scale.Add ("y", -1.5+4*(double)ward8Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward8"), w8Scale);
	}
	
	public static void renderCrimesOffense(List<CrimeEntry> crimes, string offense) {
		int ward1Count = 0, ward2Count = 0, ward3Count = 0, 
		ward4Count = 0, ward5Count = 0, ward6Count = 0, 
		ward7Count = 0, ward8Count = 0;
		int totalCount = 0;
		
		foreach (CrimeEntry crime in crimes) {
			if (crime.offense == offense) {
				switch (crime.ward) {
				case "1":
					ward1Count++;
					break;
				case "2":
					ward2Count++;
					break;
				case "3":
					ward3Count++;
					break;
				case "4":
					ward4Count++;
					break;
				case "5":
					ward5Count++;
					break;
				case "6":
					ward6Count++;
					break;
				case "7":
					ward7Count++;
					break;
				case "8":
					ward8Count++;
					break;
				default:
					break;
				}
				totalCount++;
			}
		}
		Hashtable w1Scale = new Hashtable ();
		w1Scale.Add ("y", -1.5+4*(double)ward1Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward1"), w1Scale);
		
		Hashtable w2Scale = new Hashtable ();
		w2Scale.Add ("y", -1.5+4*(double)ward2Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward2"), w2Scale);
		
		Hashtable w3Scale = new Hashtable ();
		w3Scale.Add ("y", -1.5+4*(double)ward3Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward3"), w3Scale);
		
		Hashtable w4Scale = new Hashtable ();
		w4Scale.Add ("y", -1.5+4*(double)ward4Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward4"), w4Scale);
		
		Hashtable w5Scale = new Hashtable ();
		w5Scale.Add ("y", -1.5+4*(double)ward5Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward5"), w5Scale);
		
		Hashtable w6Scale = new Hashtable ();
		w6Scale.Add ("y", -1.5+4*(double)ward6Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward6"), w6Scale);
		
		Hashtable w7Scale = new Hashtable ();
		w7Scale.Add ("y", -1.5+4*(double)ward7Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward7"), w7Scale);
		
		Hashtable w8Scale = new Hashtable ();
		w8Scale.Add ("y", -1.5+4*(double)ward8Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward8"), w8Scale);
	}
	
	public static void renderCrimesMethod(List<CrimeEntry> crimes, string method) {
		int ward1Count = 0, ward2Count = 0, ward3Count = 0, 
		ward4Count = 0, ward5Count = 0, ward6Count = 0, 
		ward7Count = 0, ward8Count = 0;
		int totalCount = 0;
		
		foreach (CrimeEntry crime in crimes) {
			if (crime.method == method) {
				switch (crime.ward) {
				case "1":
					ward1Count++;
					break;
				case "2":
					ward2Count++;
					break;
				case "3":
					ward3Count++;
					break;
				case "4":
					ward4Count++;
					break;
				case "5":
					ward5Count++;
					break;
				case "6":
					ward6Count++;
					break;
				case "7":
					ward7Count++;
					break;
				case "8":
					ward8Count++;
					break;
				default:
					break;
				}
				totalCount++;
			}
		}
		Hashtable w1Scale = new Hashtable ();
		w1Scale.Add ("y", -1.5+4*(double)ward1Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward1"), w1Scale);
		
		Hashtable w2Scale = new Hashtable ();
		w2Scale.Add ("y", -1.5+4*(double)ward2Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward2"), w2Scale);
		
		Hashtable w3Scale = new Hashtable ();
		w3Scale.Add ("y", -1.5+4*(double)ward3Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward3"), w3Scale);
		
		Hashtable w4Scale = new Hashtable ();
		w4Scale.Add ("y", -1.5+4*(double)ward4Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward4"), w4Scale);
		
		Hashtable w5Scale = new Hashtable ();
		w5Scale.Add ("y", -1.5+4*(double)ward5Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward5"), w5Scale);
		
		Hashtable w6Scale = new Hashtable ();
		w6Scale.Add ("y", -1.5+4*(double)ward6Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward6"), w6Scale);
		
		Hashtable w7Scale = new Hashtable ();
		w7Scale.Add ("y", -1.5+4*(double)ward7Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward7"), w7Scale);
		
		Hashtable w8Scale = new Hashtable ();
		w8Scale.Add ("y", -1.5+4*(double)ward8Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward8"), w8Scale);
	}
	
/****************************************************
 * 													*
 * 													*
 * 				  IMMUNIZATION DATA					*
 * 													*
 * 													*
 ****************************************************/
	
	public class ImmunizationEntry {
		public string type;
		public string ward;
	}
	
	public static List<ImmunizationEntry> loadImmunizations (){
		resetBars ();
		Dictionary<string, int> myObjectMap = new Dictionary<string, int> ();
		List<ImmunizationEntry> immunizationList = new List<ImmunizationEntry> ();
		using (CsvReader csv = new CsvReader(new StreamReader("immunization_providers.csv"), true)) {
			int fieldCount = csv.FieldCount;
			string[] headers = csv.GetFieldHeaders ();
			
			for (int i = 0; i < fieldCount; i++) {
				myObjectMap [headers [i]] = i;
			}
			while (csv.ReadNextRecord()) {
				ImmunizationEntry immunization = new ImmunizationEntry ();
				
				immunization.type = csv [myObjectMap ["Type"]];
				immunization.ward = csv [myObjectMap ["Ward"]];
				immunizationList.Add (immunization);
			}
		}
		return immunizationList;
	}
	
	public static void renderImmunizationsTotal(List<ImmunizationEntry> immunizations){
		int ward1Count = 0, ward2Count = 0, ward3Count = 0, 
		ward4Count = 0, ward5Count = 0, ward6Count = 0, 
		ward7Count = 0, ward8Count = 0;
		int totalCount = 0;
		
		foreach (ImmunizationEntry immunization in immunizations) {
			switch (immunization.ward) {
			case "1":
				ward1Count++;
				break;
			case "2":
				ward2Count++;
				break;
			case "3":
				ward3Count++;
				break;
			case "4":
				ward4Count++;
				break;
			case "5":
				ward5Count++;
				break;
			case "6":
				ward6Count++;
				break;
			case "7":
				ward7Count++;
				break;
			case "8":
				ward8Count++;
				break;
			default:
				break;
			}
			totalCount++;
		}
		Hashtable w1Scale = new Hashtable ();
		w1Scale.Add ("y", -1.5+4*(double)ward1Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward1"), w1Scale);
		
		Hashtable w2Scale = new Hashtable ();
		w2Scale.Add ("y", -1.5+4*(double)ward2Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward2"), w2Scale);
		
		Hashtable w3Scale = new Hashtable ();
		w3Scale.Add ("y", -1.5+4*(double)ward3Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward3"), w3Scale);
		
		Hashtable w4Scale = new Hashtable ();
		w4Scale.Add ("y", -1.5+4*(double)ward4Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward4"), w4Scale);
		
		Hashtable w5Scale = new Hashtable ();
		w5Scale.Add ("y", -1.5+4*(double)ward5Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward5"), w5Scale);
		
		Hashtable w6Scale = new Hashtable ();
		w6Scale.Add ("y", -1.5+4*(double)ward6Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward6"), w6Scale);
		
		Hashtable w7Scale = new Hashtable ();
		w7Scale.Add ("y", -1.5+4*(double)ward7Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward7"), w7Scale);
		
		Hashtable w8Scale = new Hashtable ();
		w8Scale.Add ("y", -1.5+4*(double)ward8Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward8"), w8Scale);
	}
	
	public static void renderImmunizationsType(List<ImmunizationEntry> immunizations, string type) {
		int ward1Count = 0, ward2Count = 0, ward3Count = 0, 
		ward4Count = 0, ward5Count = 0, ward6Count = 0, 
		ward7Count = 0, ward8Count = 0;
		int totalCount = 0;
		
		foreach (ImmunizationEntry immunization in immunizations) {
			if (immunization.type == type) {
				switch (immunization.ward) {
				case "1":
					ward1Count++;
					break;
				case "2":
					ward2Count++;
					break;
				case "3":
					ward3Count++;
					break;
				case "4":
					ward4Count++;
					break;
				case "5":
					ward5Count++;
					break;
				case "6":
					ward6Count++;
					break;
				case "7":
					ward7Count++;
					break;
				case "8":
					ward8Count++;
					break;
				default:
					break;
				}
				totalCount++;
			}
		}
		Hashtable w1Scale = new Hashtable ();
		w1Scale.Add ("y", -1.5+4*(double)ward1Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward1"), w1Scale);
		
		Hashtable w2Scale = new Hashtable ();
		w2Scale.Add ("y", -1.5+4*(double)ward2Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward2"), w2Scale);
		
		Hashtable w3Scale = new Hashtable ();
		w3Scale.Add ("y", -1.5+4*(double)ward3Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward3"), w3Scale);
		
		Hashtable w4Scale = new Hashtable ();
		w4Scale.Add ("y", -1.5+4*(double)ward4Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward4"), w4Scale);
		
		Hashtable w5Scale = new Hashtable ();
		w5Scale.Add ("y", -1.5+4*(double)ward5Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward5"), w5Scale);
		
		Hashtable w6Scale = new Hashtable ();
		w6Scale.Add ("y", -1.5+4*(double)ward6Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward6"), w6Scale);
		
		Hashtable w7Scale = new Hashtable ();
		w7Scale.Add ("y", -1.5+4*(double)ward7Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward7"), w7Scale);
		
		Hashtable w8Scale = new Hashtable ();
		w8Scale.Add ("y", -1.5+4*(double)ward8Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward8"), w8Scale);
	}
	
/****************************************************
 * 													*
 * 													*
 * 				POLLING PLACE DATA					*
 * 													*
 * 													*
 ****************************************************/
	
	public class PollingPlaceEntry {
		public string ward;
	}
	
	public static List<PollingPlaceEntry> loadPollingPlaces (){
		resetBars ();
		Dictionary<string, int> myObjectMap = new Dictionary<string, int> ();
		List<PollingPlaceEntry> pollingPlaceList = new List<PollingPlaceEntry> ();
		using (CsvReader csv = new CsvReader(new StreamReader("polling_places.csv"), true)) {
			int fieldCount = csv.FieldCount;
			string[] headers = csv.GetFieldHeaders ();
			
			for (int i = 0; i < fieldCount; i++) {
				myObjectMap [headers [i]] = i;
			}
			while (csv.ReadNextRecord()) {
				PollingPlaceEntry pollingPlace = new PollingPlaceEntry ();
				
				pollingPlace.ward = csv [myObjectMap ["WARD"]];
				pollingPlaceList.Add (pollingPlace);
			}
		}
		return pollingPlaceList;
	}
	
	public static void renderPollingPlacesTotal(List<PollingPlaceEntry> pollingPlaces){
		int ward1Count = 0, ward2Count = 0, ward3Count = 0, 
		ward4Count = 0, ward5Count = 0, ward6Count = 0, 
		ward7Count = 0, ward8Count = 0;
		int totalCount = 0;
		
		foreach (PollingPlaceEntry pollingPlace in pollingPlaces) {
			switch (pollingPlace.ward) {
			case "Ward 1":
				ward1Count++;
				break;
			case "Ward 2":
				ward2Count++;
				break;
			case "Ward 3":
				ward3Count++;
				break;
			case "Ward 4":
				ward4Count++;
				break;
			case "Ward 5":
				ward5Count++;
				break;
			case "Ward 6":
				ward6Count++;
				break;
			case "Ward 7":
				ward7Count++;
				break;
			case "Ward 8":
				ward8Count++;
				break;
			default:
				break;
			}
			totalCount++;
		}
		Hashtable w1Scale = new Hashtable ();
		w1Scale.Add ("y", -1.5+4*(double)ward1Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward1"), w1Scale);
		
		Hashtable w2Scale = new Hashtable ();
		w2Scale.Add ("y", -1.5+4*(double)ward2Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward2"), w2Scale);
		
		Hashtable w3Scale = new Hashtable ();
		w3Scale.Add ("y", -1.5+4*(double)ward3Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward3"), w3Scale);
		
		Hashtable w4Scale = new Hashtable ();
		w4Scale.Add ("y", -1.5+4*(double)ward4Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward4"), w4Scale);
		
		Hashtable w5Scale = new Hashtable ();
		w5Scale.Add ("y", -1.5+4*(double)ward5Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward5"), w5Scale);
		
		Hashtable w6Scale = new Hashtable ();
		w6Scale.Add ("y", -1.5+4*(double)ward6Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward6"), w6Scale);
		
		Hashtable w7Scale = new Hashtable ();
		w7Scale.Add ("y", -1.5+4*(double)ward7Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward7"), w7Scale);
		
		Hashtable w8Scale = new Hashtable ();
		w8Scale.Add ("y", -1.5+4*(double)ward8Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward8"), w8Scale);
	}
	
/****************************************************
 * 													*
 * 													*
 * 				POPULATION DATA						*
 * 													*
 * 													*
 ****************************************************/
	
	public class PopulationEntry {
		public string ward;
		public string populationDensity;
		public string population;
		public string highSchoolDegreePercent;
		public string collegeDegreePercent;
		public string gradDegreePercent;
		public string unemployedPercent;
		public string medianHouseholdIncome;
		public string familiesInPovertyPercent;
		public string individualsInPovertyPercent;
		public string age65Plus;
		public string youth;
	}
	
	public static List<PopulationEntry> loadPopulation (){
		resetBars ();
		Dictionary<string, int> myObjectMap = new Dictionary<string, int> ();
		List<PopulationEntry> populationList = new List<PopulationEntry> ();
		using (CsvReader csv = new CsvReader(new StreamReader("population.csv"), true)) {
			int fieldCount = csv.FieldCount;
			string[] headers = csv.GetFieldHeaders ();
			
			for (int i = 0; i < fieldCount; i++) {
				myObjectMap [headers [i]] = i;
			}
			while (csv.ReadNextRecord()) {
				PopulationEntry population = new PopulationEntry ();
				
				population.ward = csv [myObjectMap ["WARD_ID"]];
				population.populationDensity = csv [myObjectMap ["POPDENSITY"]];
				population.population = csv [myObjectMap ["POP2000"]];
				population.highSchoolDegreePercent = csv [myObjectMap ["HSCH_PC"]];
				population.collegeDegreePercent = csv [myObjectMap ["BACH_PC"]];
				population.gradDegreePercent = csv [myObjectMap ["GRAD_PC"]];
				population.unemployedPercent = csv [myObjectMap["UNEMP_PC"]];
				population.medianHouseholdIncome = csv [myObjectMap ["MINC_DL"]];
				population.familiesInPovertyPercent = csv [myObjectMap ["POVFAM_"]];
				population.individualsInPovertyPercent = csv [myObjectMap["POVIND_"]];
				population.age65Plus = csv [myObjectMap ["AGE_65_"]];
				population.youth = csv [myObjectMap ["TOTAL_YOUT"]];
				
				populationList.Add (population);
			}
		}
		return populationList;
	}
	
	public static void renderPopulationDensity(List<PopulationEntry> populations){
		double ward1Count = 0, ward2Count = 0, ward3Count = 0, 
		ward4Count = 0, ward5Count = 0, ward6Count = 0, 
		ward7Count = 0, ward8Count = 0;
		double totalCount = 0;
		
		foreach (PopulationEntry population in populations) {
			double popDensity = Convert.ToDouble(population.populationDensity);
			
			switch (population.ward) {
			case "1":
				ward1Count = popDensity;
				break;
			case "2":
				ward2Count = popDensity;
				break;
			case "3":
				ward3Count = popDensity;
				break;
			case "4":
				ward4Count = popDensity;
				break;
			case "5":
				ward5Count = popDensity;
				break;
			case "6":
				ward6Count = popDensity;
				break;
			case "7":
				ward7Count = popDensity;
				break;
			case "8":
				ward8Count = popDensity;
				break;
			default:
				break;
			}
			totalCount+= popDensity;
		}
		Hashtable w1Scale = new Hashtable ();
		w1Scale.Add ("y", -1.5+4*(double)ward1Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward1"), w1Scale);
		
		Hashtable w2Scale = new Hashtable ();
		w2Scale.Add ("y", -1.5+4*(double)ward2Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward2"), w2Scale);
		
		Hashtable w3Scale = new Hashtable ();
		w3Scale.Add ("y", -1.5+4*(double)ward3Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward3"), w3Scale);
		
		Hashtable w4Scale = new Hashtable ();
		w4Scale.Add ("y", -1.5+4*(double)ward4Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward4"), w4Scale);
		
		Hashtable w5Scale = new Hashtable ();
		w5Scale.Add ("y", -1.5+4*(double)ward5Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward5"), w5Scale);
		
		Hashtable w6Scale = new Hashtable ();
		w6Scale.Add ("y", -1.5+4*(double)ward6Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward6"), w6Scale);
		
		Hashtable w7Scale = new Hashtable ();
		w7Scale.Add ("y", -1.5+4*(double)ward7Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward7"), w7Scale);
		
		Hashtable w8Scale = new Hashtable ();
		w8Scale.Add ("y", -1.5+4*(double)ward8Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward8"), w8Scale);
	}
	
	public static void renderTotalPopulation(List<PopulationEntry> populations){
		double ward1Count = 0, ward2Count = 0, ward3Count = 0, 
		ward4Count = 0, ward5Count = 0, ward6Count = 0, 
		ward7Count = 0, ward8Count = 0;
		double totalCount = 0;
		
		foreach (PopulationEntry population in populations) {
			double totalPop = Convert.ToDouble(population.population);
			
			switch (population.ward) {
			case "1":
				ward1Count = totalPop;
				break;
			case "2":
				ward2Count = totalPop;
				break;
			case "3":
				ward3Count = totalPop;
				break;
			case "4":
				ward4Count = totalPop;
				break;
			case "5":
				ward5Count = totalPop;
				break;
			case "6":
				ward6Count = totalPop;
				break;
			case "7":
				ward7Count = totalPop;
				break;
			case "8":
				ward8Count = totalPop;
				break;
			default:
				break;
			}
			totalCount+= totalPop;
		}
		Hashtable w1Scale = new Hashtable ();
		w1Scale.Add ("y", -1.5+4*(double)ward1Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward1"), w1Scale);
		
		Hashtable w2Scale = new Hashtable ();
		w2Scale.Add ("y", -1.5+4*(double)ward2Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward2"), w2Scale);
		
		Hashtable w3Scale = new Hashtable ();
		w3Scale.Add ("y", -1.5+4*(double)ward3Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward3"), w3Scale);
		
		Hashtable w4Scale = new Hashtable ();
		w4Scale.Add ("y", -1.5+4*(double)ward4Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward4"), w4Scale);
		
		Hashtable w5Scale = new Hashtable ();
		w5Scale.Add ("y", -1.5+4*(double)ward5Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward5"), w5Scale);
		
		Hashtable w6Scale = new Hashtable ();
		w6Scale.Add ("y", -1.5+4*(double)ward6Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward6"), w6Scale);
		
		Hashtable w7Scale = new Hashtable ();
		w7Scale.Add ("y", -1.5+4*(double)ward7Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward7"), w7Scale);
		
		Hashtable w8Scale = new Hashtable ();
		w8Scale.Add ("y", -1.5+4*(double)ward8Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward8"), w8Scale);
	}
	
	public static void renderPopulationHighSchoolDegree(List<PopulationEntry> populations){
		double ward1Count = 0, ward2Count = 0, ward3Count = 0, 
		ward4Count = 0, ward5Count = 0, ward6Count = 0, 
		ward7Count = 0, ward8Count = 0;
		double totalCount = 100;
		
		foreach (PopulationEntry population in populations) {
			double HSDPercent = Convert.ToDouble(population.highSchoolDegreePercent);
			HSDPercent = 100-HSDPercent;//Percentage without is more interesting
			switch (population.ward) {
			case "1":
				ward1Count =  HSDPercent;
				break;
			case "2":
				ward2Count = HSDPercent;
				break;
			case "3":
				ward3Count = HSDPercent;
				break;
			case "4":
				ward4Count = HSDPercent;
				break;
			case "5":
				ward5Count = HSDPercent;
				break;
			case "6":
				ward6Count = HSDPercent;
				break;
			case "7":
				ward7Count = HSDPercent;
				break;
			case "8":
				ward8Count = HSDPercent;
				break;
			default:
				break;
			}
		}
		Hashtable w1Scale = new Hashtable ();
		w1Scale.Add ("y", -1.5+4*(double)ward1Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward1"), w1Scale);
		
		Hashtable w2Scale = new Hashtable ();
		w2Scale.Add ("y", -1.5+4*(double)ward2Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward2"), w2Scale);
		
		Hashtable w3Scale = new Hashtable ();
		w3Scale.Add ("y", -1.5+4*(double)ward3Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward3"), w3Scale);
		
		Hashtable w4Scale = new Hashtable ();
		w4Scale.Add ("y", -1.5+4*(double)ward4Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward4"), w4Scale);
		
		Hashtable w5Scale = new Hashtable ();
		w5Scale.Add ("y", -1.5+4*(double)ward5Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward5"), w5Scale);
		
		Hashtable w6Scale = new Hashtable ();
		w6Scale.Add ("y", -1.5+4*(double)ward6Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward6"), w6Scale);
		
		Hashtable w7Scale = new Hashtable ();
		w7Scale.Add ("y", -1.5+4*(double)ward7Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward7"), w7Scale);
		
		Hashtable w8Scale = new Hashtable ();
		w8Scale.Add ("y", -1.5+4*(double)ward8Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward8"), w8Scale);
	}
	
	public static void renderPopulationCollegeDegree(List<PopulationEntry> populations){
		double ward1Count = 0, ward2Count = 0, ward3Count = 0, 
		ward4Count = 0, ward5Count = 0, ward6Count = 0, 
		ward7Count = 0, ward8Count = 0;
		int totalCount = 100;
		
		foreach (PopulationEntry population in populations) {
			double CDPercent = Convert.ToDouble(population.collegeDegreePercent);
			
			switch (population.ward) {
			case "1":
				ward1Count = CDPercent;
				break;
			case "2":
				ward2Count = CDPercent;
				break;
			case "3":
				ward3Count = CDPercent;
				break;
			case "4":
				ward4Count = CDPercent;
				break;
			case "5":
				ward5Count = CDPercent;
				break;
			case "6":
				ward6Count = CDPercent;
				break;
			case "7":
				ward7Count = CDPercent;
				break;
			case "8":
				ward8Count = CDPercent;
				break;
			default:
				break;
			}
		}
		Hashtable w1Scale = new Hashtable ();
		w1Scale.Add ("y", -1.5+4*(double)ward1Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward1"), w1Scale);
		
		Hashtable w2Scale = new Hashtable ();
		w2Scale.Add ("y", -1.5+4*(double)ward2Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward2"), w2Scale);
		
		Hashtable w3Scale = new Hashtable ();
		w3Scale.Add ("y", -1.5+4*(double)ward3Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward3"), w3Scale);
		
		Hashtable w4Scale = new Hashtable ();
		w4Scale.Add ("y", -1.5+4*(double)ward4Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward4"), w4Scale);
		
		Hashtable w5Scale = new Hashtable ();
		w5Scale.Add ("y", -1.5+4*(double)ward5Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward5"), w5Scale);
		
		Hashtable w6Scale = new Hashtable ();
		w6Scale.Add ("y", -1.5+4*(double)ward6Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward6"), w6Scale);
		
		Hashtable w7Scale = new Hashtable ();
		w7Scale.Add ("y", -1.5+4*(double)ward7Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward7"), w7Scale);
		
		Hashtable w8Scale = new Hashtable ();
		w8Scale.Add ("y", -1.5+4*(double)ward8Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward8"), w8Scale);
	}
	
	public static void renderPopulationGradDegree(List<PopulationEntry> populations){
		double ward1Count = 0, ward2Count = 0, ward3Count = 0, 
		ward4Count = 0, ward5Count = 0, ward6Count = 0, 
		ward7Count = 0, ward8Count = 0;
		int totalCount = 100;
		
		foreach (PopulationEntry population in populations) {
			double GDPercent = Convert.ToDouble(population.gradDegreePercent);
			
			switch (population.ward) {
			case "1":
				ward1Count = GDPercent;
				break;
			case "2":
				ward2Count = GDPercent;
				break;
			case "3":
				ward3Count = GDPercent;
				break;
			case "4":
				ward4Count = GDPercent;
				break;
			case "5":
				ward5Count = GDPercent;
				break;
			case "6":
				ward6Count = GDPercent;
				break;
			case "7":
				ward7Count = GDPercent;
				break;
			case "8":
				ward8Count = GDPercent;
				break;
			default:
				break;
			}
		}
		Hashtable w1Scale = new Hashtable ();
		w1Scale.Add ("y", -1.5+4*(double)ward1Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward1"), w1Scale);
		
		Hashtable w2Scale = new Hashtable ();
		w2Scale.Add ("y", -1.5+4*(double)ward2Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward2"), w2Scale);
		
		Hashtable w3Scale = new Hashtable ();
		w3Scale.Add ("y", -1.5+4*(double)ward3Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward3"), w3Scale);
		
		Hashtable w4Scale = new Hashtable ();
		w4Scale.Add ("y", -1.5+4*(double)ward4Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward4"), w4Scale);
		
		Hashtable w5Scale = new Hashtable ();
		w5Scale.Add ("y", -1.5+4*(double)ward5Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward5"), w5Scale);
		
		Hashtable w6Scale = new Hashtable ();
		w6Scale.Add ("y", -1.5+4*(double)ward6Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward6"), w6Scale);
		
		Hashtable w7Scale = new Hashtable ();
		w7Scale.Add ("y", -1.5+4*(double)ward7Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward7"), w7Scale);
		
		Hashtable w8Scale = new Hashtable ();
		w8Scale.Add ("y", -1.5+4*(double)ward8Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward8"), w8Scale);
	}
	
	public static void renderPopulationUnemployed(List<PopulationEntry> populations){
		double ward1Count = 0, ward2Count = 0, ward3Count = 0, 
		ward4Count = 0, ward5Count = 0, ward6Count = 0, 
		ward7Count = 0, ward8Count = 0;
		int totalCount = 100;
		
		foreach (PopulationEntry population in populations) {
			double UPercent = Convert.ToDouble(population.unemployedPercent);
			
			switch (population.ward) {
			case "1":
				ward1Count = UPercent;
				break;
			case "2":
				ward2Count = UPercent;
				break;
			case "3":
				ward3Count = UPercent;
				break;
			case "4":
				ward4Count = UPercent;
				break;
			case "5":
				ward5Count = UPercent;
				break;
			case "6":
				ward6Count = UPercent;
				break;
			case "7":
				ward7Count = UPercent;
				break;
			case "8":
				ward8Count = UPercent;
				break;
			default:
				break;
			}
		}
		Hashtable w1Scale = new Hashtable ();
		w1Scale.Add ("y", -1.5+4*(double)ward1Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward1"), w1Scale);
		
		Hashtable w2Scale = new Hashtable ();
		w2Scale.Add ("y", -1.5+4*(double)ward2Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward2"), w2Scale);
		
		Hashtable w3Scale = new Hashtable ();
		w3Scale.Add ("y", -1.5+4*(double)ward3Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward3"), w3Scale);
		
		Hashtable w4Scale = new Hashtable ();
		w4Scale.Add ("y", -1.5+4*(double)ward4Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward4"), w4Scale);
		
		Hashtable w5Scale = new Hashtable ();
		w5Scale.Add ("y", -1.5+4*(double)ward5Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward5"), w5Scale);
		
		Hashtable w6Scale = new Hashtable ();
		w6Scale.Add ("y", -1.5+4*(double)ward6Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward6"), w6Scale);
		
		Hashtable w7Scale = new Hashtable ();
		w7Scale.Add ("y", -1.5+4*(double)ward7Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward7"), w7Scale);
		
		Hashtable w8Scale = new Hashtable ();
		w8Scale.Add ("y", -1.5+4*(double)ward8Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward8"), w8Scale);

		Debug.Log (w8Scale);

	}
	
	public static void renderPopulationMedianHouseholdIncome(List<PopulationEntry> populations){
		double ward1Count = 0, ward2Count = 0, ward3Count = 0, 
		ward4Count = 0, ward5Count = 0, ward6Count = 0, 
		ward7Count = 0, ward8Count = 0;
		double totalCount = 0;
		
		foreach (PopulationEntry population in populations) {
			double medianIncome = Convert.ToDouble(population.medianHouseholdIncome);
			
			switch (population.ward) {
			case "1":
				ward1Count = medianIncome;
				break;
			case "2":
				ward2Count = medianIncome;
				break;
			case "3":
				ward3Count = medianIncome;
				break;
			case "4":
				ward4Count = medianIncome;
				break;
			case "5":
				ward5Count = medianIncome;
				break;
			case "6":
				ward6Count = medianIncome;
				break;
			case "7":
				ward7Count = medianIncome;
				break;
			case "8":
				ward8Count = medianIncome;
				break;
			default:
				break;
			}
			totalCount+= medianIncome;
		}
		Hashtable w1Scale = new Hashtable ();
		w1Scale.Add ("y", -1.5+4*(double)ward1Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward1"), w1Scale);
		
		Hashtable w2Scale = new Hashtable ();
		w2Scale.Add ("y", -1.5+4*(double)ward2Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward2"), w2Scale);
		
		Hashtable w3Scale = new Hashtable ();
		w3Scale.Add ("y", -1.5+4*(double)ward3Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward3"), w3Scale);
		
		Hashtable w4Scale = new Hashtable ();
		w4Scale.Add ("y", -1.5+4*(double)ward4Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward4"), w4Scale);
		
		Hashtable w5Scale = new Hashtable ();
		w5Scale.Add ("y", -1.5+4*(double)ward5Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward5"), w5Scale);
		
		Hashtable w6Scale = new Hashtable ();
		w6Scale.Add ("y", -1.5+4*(double)ward6Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward6"), w6Scale);
		
		Hashtable w7Scale = new Hashtable ();
		w7Scale.Add ("y", -1.5+4*(double)ward7Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward7"), w7Scale);
		
		Hashtable w8Scale = new Hashtable ();
		w8Scale.Add ("y", -1.5+4*(double)ward8Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward8"), w8Scale);
	}
	
	public static void renderPopulationFamiliesInPoverty(List<PopulationEntry> populations){
		double ward1Count = 0, ward2Count = 0, ward3Count = 0, 
		ward4Count = 0, ward5Count = 0, ward6Count = 0, 
		ward7Count = 0, ward8Count = 0;
		int totalCount = 100;
		
		foreach (PopulationEntry population in populations) {
			double FPPercent = Convert.ToDouble(population.familiesInPovertyPercent);
			
			switch (population.ward) {
			case "1":
				ward1Count = FPPercent;
				break;
			case "2":
				ward2Count = FPPercent;
				break;
			case "3":
				ward3Count = FPPercent;
				break;
			case "4":
				ward4Count = FPPercent;
				break;
			case "5":
				ward5Count = FPPercent;
				break;
			case "6":
				ward6Count = FPPercent;
				break;
			case "7":
				ward7Count = FPPercent;
				break;
			case "8":
				ward8Count = FPPercent;
				break;
			default:
				break;
			}
		}
		Hashtable w1Scale = new Hashtable ();
		w1Scale.Add ("y", -1.5+4*(double)ward1Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward1"), w1Scale);
		
		Hashtable w2Scale = new Hashtable ();
		w2Scale.Add ("y", -1.5+4*(double)ward2Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward2"), w2Scale);
		
		Hashtable w3Scale = new Hashtable ();
		w3Scale.Add ("y", -1.5+4*(double)ward3Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward3"), w3Scale);
		
		Hashtable w4Scale = new Hashtable ();
		w4Scale.Add ("y", -1.5+4*(double)ward4Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward4"), w4Scale);
		
		Hashtable w5Scale = new Hashtable ();
		w5Scale.Add ("y", -1.5+4*(double)ward5Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward5"), w5Scale);
		
		Hashtable w6Scale = new Hashtable ();
		w6Scale.Add ("y", -1.5+4*(double)ward6Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward6"), w6Scale);
		
		Hashtable w7Scale = new Hashtable ();
		w7Scale.Add ("y", -1.5+4*(double)ward7Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward7"), w7Scale);
		
		Hashtable w8Scale = new Hashtable ();
		w8Scale.Add ("y", -1.5+4*(double)ward8Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward8"), w8Scale);
	}
	
	public static void renderPopulationIndividualsInPoverty(List<PopulationEntry> populations){
		double ward1Count = 0, ward2Count = 0, ward3Count = 0, 
		ward4Count = 0, ward5Count = 0, ward6Count = 0, 
		ward7Count = 0, ward8Count = 0;
		int totalCount = 100;
		
		foreach (PopulationEntry population in populations) {
			double IPPercent = Convert.ToDouble(population.individualsInPovertyPercent);
			
			switch (population.ward) {
			case "1":
				ward1Count = IPPercent;
				break;
			case "2":
				ward2Count = IPPercent;
				break;
			case "3":
				ward3Count = IPPercent;
				break;
			case "4":
				ward4Count = IPPercent;
				break;
			case "5":
				ward5Count = IPPercent;
				break;
			case "6":
				ward6Count = IPPercent;
				break;
			case "7":
				ward7Count = IPPercent;
				break;
			case "8":
				ward8Count = IPPercent;
				break;
			default:
				break;
			}
		}
		Hashtable w1Scale = new Hashtable ();
		w1Scale.Add ("y", -1.5+4*(double)ward1Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward1"), w1Scale);
		
		Hashtable w2Scale = new Hashtable ();
		w2Scale.Add ("y", -1.5+4*(double)ward2Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward2"), w2Scale);
		
		Hashtable w3Scale = new Hashtable ();
		w3Scale.Add ("y", -1.5+4*(double)ward3Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward3"), w3Scale);
		
		Hashtable w4Scale = new Hashtable ();
		w4Scale.Add ("y", -1.5+4*(double)ward4Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward4"), w4Scale);
		
		Hashtable w5Scale = new Hashtable ();
		w5Scale.Add ("y", -1.5+4*(double)ward5Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward5"), w5Scale);
		
		Hashtable w6Scale = new Hashtable ();
		w6Scale.Add ("y", -1.5+4*(double)ward6Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward6"), w6Scale);
		
		Hashtable w7Scale = new Hashtable ();
		w7Scale.Add ("y", -1.5+4*(double)ward7Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward7"), w7Scale);
		
		Hashtable w8Scale = new Hashtable ();
		w8Scale.Add ("y", -1.5+4*(double)ward8Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward8"), w8Scale);
	}
	
	public static void renderPopulationAge65Plus(List<PopulationEntry> populations){
		double ward1Count = 0, ward2Count = 0, ward3Count = 0, 
		ward4Count = 0, ward5Count = 0, ward6Count = 0, 
		ward7Count = 0, ward8Count = 0;
		double totalCount = 0;
		
		foreach (PopulationEntry population in populations) {
			double pop65Plus = Convert.ToDouble(population.age65Plus);
			
			switch (population.ward) {
			case "1":
				ward1Count = pop65Plus;
				break;
			case "2":
				ward2Count = pop65Plus;
				break;
			case "3":
				ward3Count = pop65Plus;
				break;
			case "4":
				ward4Count = pop65Plus;
				break;
			case "5":
				ward5Count = pop65Plus;
				break;
			case "6":
				ward6Count = pop65Plus;
				break;
			case "7":
				ward7Count = pop65Plus;
				break;
			case "8":
				ward8Count = pop65Plus;
				break;
			default:
				break;
			}
			totalCount+= pop65Plus;
		}
		Hashtable w1Scale = new Hashtable ();
		w1Scale.Add ("y", -1.5+4*(double)ward1Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward1"), w1Scale);
		
		Hashtable w2Scale = new Hashtable ();
		w2Scale.Add ("y", -1.5+4*(double)ward2Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward2"), w2Scale);
		
		Hashtable w3Scale = new Hashtable ();
		w3Scale.Add ("y", -1.5+4*(double)ward3Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward3"), w3Scale);
		
		Hashtable w4Scale = new Hashtable ();
		w4Scale.Add ("y", -1.5+4*(double)ward4Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward4"), w4Scale);
		
		Hashtable w5Scale = new Hashtable ();
		w5Scale.Add ("y", -1.5+4*(double)ward5Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward5"), w5Scale);
		
		Hashtable w6Scale = new Hashtable ();
		w6Scale.Add ("y", -1.5+4*(double)ward6Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward6"), w6Scale);
		
		Hashtable w7Scale = new Hashtable ();
		w7Scale.Add ("y", -1.5+4*(double)ward7Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward7"), w7Scale);
		
		Hashtable w8Scale = new Hashtable ();
		w8Scale.Add ("y", -1.5+4*(double)ward8Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward8"), w8Scale);
	}
	
	public static void renderPopulationYouth(List<PopulationEntry> populations){
		double ward1Count = 0, ward2Count = 0, ward3Count = 0, 
		ward4Count = 0, ward5Count = 0, ward6Count = 0, 
		ward7Count = 0, ward8Count = 0;
		double totalCount = 0;
		
		foreach (PopulationEntry population in populations) {
			double popYouth = Convert.ToDouble(population.youth);
			
			switch (population.ward) {
			case "1":
				ward1Count = popYouth;
				break;
			case "2":
				ward2Count = popYouth;
				break;
			case "3":
				ward3Count = popYouth;
				break;
			case "4":
				ward4Count = popYouth;
				break;
			case "5":
				ward5Count = popYouth;
				break;
			case "6":
				ward6Count = popYouth;
				break;
			case "7":
				ward7Count = popYouth;
				break;
			case "8":
				ward8Count = popYouth;
				break;
			default:
				break;
			}
			totalCount+= popYouth;
		}
		Hashtable w1Scale = new Hashtable ();
		w1Scale.Add ("y", -1.5+4*(double)ward1Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward1"), w1Scale);
		
		Hashtable w2Scale = new Hashtable ();
		w2Scale.Add ("y", -1.5+4*(double)ward2Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward2"), w2Scale);
		
		Hashtable w3Scale = new Hashtable ();
		w3Scale.Add ("y", -1.5+4*(double)ward3Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward3"), w3Scale);
		
		Hashtable w4Scale = new Hashtable ();
		w4Scale.Add ("y", -1.5+4*(double)ward4Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward4"), w4Scale);
		
		Hashtable w5Scale = new Hashtable ();
		w5Scale.Add ("y", -1.5+4*(double)ward5Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward5"), w5Scale);
		
		Hashtable w6Scale = new Hashtable ();
		w6Scale.Add ("y", -1.5+4*(double)ward6Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward6"), w6Scale);
		
		Hashtable w7Scale = new Hashtable ();
		w7Scale.Add ("y", -1.5+4*(double)ward7Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward7"), w7Scale);
		
		Hashtable w8Scale = new Hashtable ();
		w8Scale.Add ("y", -1.5+4*(double)ward8Count / (double)totalCount);
		iTween.MoveTo (GameObject.Find ("Ward8"), w8Scale);
	}

	public static void resetBars(){
		Hashtable w1Scale = new Hashtable ();
		w1Scale.Add ("y", -1.5);
		iTween.MoveTo (GameObject.Find ("Ward1"), w1Scale);
		
		Hashtable w2Scale = new Hashtable ();
		w2Scale.Add ("y", -1.5);
		iTween.MoveTo (GameObject.Find ("Ward2"), w2Scale);
		
		Hashtable w3Scale = new Hashtable ();
		w3Scale.Add ("y", -1.5);
		iTween.MoveTo (GameObject.Find ("Ward3"), w3Scale);
		
		Hashtable w4Scale = new Hashtable ();
		w4Scale.Add ("y", -1.5);
		iTween.MoveTo (GameObject.Find ("Ward4"), w4Scale);
		
		Hashtable w5Scale = new Hashtable ();
		w5Scale.Add ("y", -1.5);
		iTween.MoveTo (GameObject.Find ("Ward5"), w5Scale);
		
		Hashtable w6Scale = new Hashtable ();
		w6Scale.Add ("y", -1.5);
		iTween.MoveTo (GameObject.Find ("Ward6"), w6Scale);
		
		Hashtable w7Scale = new Hashtable ();
		w7Scale.Add ("y", -1.5);
		iTween.MoveTo (GameObject.Find ("Ward7"), w7Scale);
		
		Hashtable w8Scale = new Hashtable ();
		w8Scale.Add ("y", -1.5);
		iTween.MoveTo (GameObject.Find ("Ward8"), w8Scale);
	}
}