using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
///
/// Summary
///
public class Wave
{
	/// <summary>
	/// Tempo entre ondas de inimigos.
	/// </summary>
	public float waveGap;
	
	/// <summary>
	/// Configuração da onda de inimigos.
	/// </summary>
	public WaveUnits[] waveUnits;
}


[System.Serializable]
/// <summary>
/// Configuração da onda de inimigos.
/// </summary>
/// <param numberOfUnits="# of Units">Numero de unidades do mesmo tipo</param>
/// <param unit="Unit Type">Unidade que vai ser spawnada na wave</param>
public class WaveUnits
{
	/// <summary>
	/// Numero de unidades do mesmo tipo.
	/// </summary>
	public int numberOfUnits;

	/// <summary>
	/// Tempo entre unidades.
	/// </summary>
	public float gapBtwnUnits;

	/// <summary>
	/// Unidade que vai ser spawnada na wave.
	/// </summary>
	public GameObject unitGameObj;
}