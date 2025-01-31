using System;
using UnityEngine;


// Token: 0x02000010 RID: 16
public class CameraShake : MonoBehaviour
{
	// Token: 0x0600006C RID: 108 RVA: 0x00003F59 File Offset: 0x00002159
	private void Awake()
	{
		if (this.camTransform == null)
		{
			this.camTransform = base.transform;
		}
		this.originalPos = this.camTransform.localPosition;
	}

	// Token: 0x0600006D RID: 109 RVA: 0x00003F86 File Offset: 0x00002186
	public static void ShakeOnce(float lenght, float strength)
	{
		CameraShake.shakeDuration = lenght;
		CameraShake.shakeAmount = strength;
	}

	// Token: 0x0600006E RID: 110 RVA: 0x00003F94 File Offset: 0x00002194
	private void Update()
	{
		if (CameraShake.shakeDuration > 0f)
		{
			Vector3 target = this.originalPos + UnityEngine.Random.insideUnitSphere * CameraShake.shakeAmount;
			this.camTransform.localPosition = Vector3.SmoothDamp(this.camTransform.localPosition, target, ref this.vel2, 0.05f);
			CameraShake.shakeDuration -= Time.deltaTime;
			CameraShake.shakeAmount = Mathf.SmoothDamp(CameraShake.shakeAmount, 0f, ref this.vel, 0.7f);
			return;
		}
		this.camTransform.localPosition = this.originalPos;
	}

	// Token: 0x04000059 RID: 89
	public Transform camTransform;

	// Token: 0x0400005A RID: 90
	private static float shakeDuration = 0f;

	// Token: 0x0400005B RID: 91
	private static float shakeAmount = 0.7f;

	// Token: 0x0400005C RID: 92
	private float vel;

	// Token: 0x0400005D RID: 93
	private Vector3 vel2 = Vector3.zero;

	// Token: 0x0400005E RID: 94
	private Vector3 originalPos;
}
