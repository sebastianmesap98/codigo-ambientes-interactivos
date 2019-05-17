using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class enviarDatos : MonoBehaviour {

    SerialPort puerto = new SerialPort("COM4", 9600);

    private int IdUser;
	private int pose = 1;
	private int [] poten= new int[9];
	private bool conectado;
	private string urlEnvio = "http://tadeolabhack.com:8081/test/animacion/envioDatos.php" ;
    string[] datos;


    void Start () {
        puerto.Open();
        puerto.ReadTimeout = 1;
        StartCoroutine(comprobarConec());
		StartCoroutine (conseguirId());
	}

    void Update() {
        if (puerto.IsOpen)
        {
            try
            {

                string datosCadena = puerto.ReadLine();
                datos = datosCadena.Split('T');
                for (int i = 0; i < datos.Length; i++)
                {
                    print(datos[0] + datos[1] + datos[2] + datos[3] + datos[4] + datos[5] + datos[6] + datos[7] + datos[8]);
                }

              
                GameObject.FindGameObjectWithTag("BrazoDer").transform.rotation = Quaternion.Euler(0, 0, int.Parse(datos[0]));
                GameObject.FindGameObjectWithTag("CodoDer").transform.rotation = Quaternion.Euler(0, 0, int.Parse(datos[1]));
                GameObject.FindGameObjectWithTag("BrazoIzq").transform.rotation = Quaternion.Euler(0, 0, int.Parse(datos[2]));
                GameObject.FindGameObjectWithTag("CodoIzq").transform.rotation = Quaternion.Euler(0, 0, int.Parse(datos[3]));
                GameObject.FindGameObjectWithTag("PiernaDer").transform.rotation = Quaternion.Euler(0, 0, int.Parse(datos[4]));
                GameObject.FindGameObjectWithTag("RodillaDer").transform.rotation = Quaternion.Euler(0, 0, int.Parse(datos[5]));
                GameObject.FindGameObjectWithTag("PiernaIzq").transform.rotation = Quaternion.Euler(0, 0, int.Parse(datos[6]));
                GameObject.FindGameObjectWithTag("RodillaIzq").transform.rotation = Quaternion.Euler(0, 0, int.Parse(datos[7]));
                // GameObject.FindGameObjectWithTag("Cabeza").transform.position  = new Vector3 (0,int.Parse(datos[8]));


            }

            catch (System.Exception)
            {


            }
        }


    }

	public IEnumerator comprobarConec (){
	
		conectado = false;

		string dir = "http://tadeolabhack.com:8081/test/animacion/conexion.php?conexion=conectado";
		WWW getCon = new WWW (dir);

		yield return getCon;

		if (getCon.text == "sisas") {
		
			conectado = true;
		
			Debug.Log(conectado);
		}
	
	}

	public IEnumerator conseguirId(){

		string dir = "http://tadeolabhack.com:8081/test/Animacion/conseguirId.php";
		WWW getId = new WWW (dir);

		yield return getId;

		IdUser = int.Parse(getId.text.Trim());

		Debug.Log (IdUser);

	}
		
	public void enviarPoten(){

		//chef quita esto, te amo, la gracia es  
		//cambiar los valores del arreglo por
		//la lectura de los potenciometros
		for (int i=0;i<poten.Length;i++){

            poten[i] = int.Parse(datos[i]);

        }

        StartCoroutine (envio ());

		pose++;

	}

	public IEnumerator envio(){

		WWWForm datos = new WWWForm ();

		datos.AddField("UserId",IdUser);
		Debug.Log (IdUser);
		datos.AddField("Pose",pose);
		Debug.Log (pose);

		for (int i=0;i<poten.Length;i++){

			datos.AddField("Pot"+(i+1),poten[i]);
			Debug.Log (poten[i]);
		}

		WWW envio = new WWW(urlEnvio,datos);

		yield return envio;

		Debug.Log (envio.text);
	}

}
