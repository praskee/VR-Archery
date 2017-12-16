var resWidth : int = 4096; 
var resHeight : int = 2232; 

function Update() 
{ 
   if (Input.GetKeyDown ("k")) 
   { 
	   var rt = new RenderTexture(resWidth, resHeight, 24);    
	   GetComponent.<Camera>().targetTexture = rt; 
	   var screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false); 
	   GetComponent.<Camera>().Render(); 
	   RenderTexture.active = rt;
	   screenShot.ReadPixels(Rect(0, 0, resWidth, resHeight), 0, 0); 
	   RenderTexture.active = null; // JC: added to avoid errors 
	   GetComponent.<Camera>().targetTexture = null;
	   Destroy(rt);
	   var bytes = screenShot.EncodeToPNG(); 
	   System.IO.File.WriteAllBytes(Application.dataPath + "/screenshots/screen" + System.DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + ".png", bytes); 
   }    
}