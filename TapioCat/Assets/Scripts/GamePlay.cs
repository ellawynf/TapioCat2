using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    // options are "empty", "cooking", "full"
    public static string topping1Cook = "empty";
    public static string topping2Cook = "empty";
    public static string topping3Cook = "empty";

    public static string tea1Cook = "empty";
    public static string tea2Cook = "empty";
    public static string tea3Cook = "empty";

    // plating station
    // options are "none", "empty", "tea", "full"
    public static string plate1Cup = "none";        // ice cup
    public static string plate2Cup = "none";        // hot cup
    // options are "0", "1", "2", "3"
    public static int plate1Topping = 0;
    public static int plate1Tea = 0;
    public static int plate2Topping = 0;
    public static int plate2Tea = 0;

    // blender station
    // options are "empty", "cooking", "full"
    public static string blender = "empty";
    // options are "0", "1", "2", "3"
    public static int blender_contents = 0;

    //player options
    //options are false or true
    public static bool pickup = false;
    //real options are from "000" to "122" and is set to "None" on default
    public static string pickedDrink = "None";
    //I'm putting this here for testing, but it prob should go higher
    //options are "0" to "3"
    public static int totalScore = 0;
    //
}
