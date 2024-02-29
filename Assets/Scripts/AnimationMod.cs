using UnityEngine;

public class AnimationMod : MonoBehaviour
{
    public Animator animator;
    public Weapon weapon;

    public void SubscribeEvents()
    {
        weapon.onShoot.AddListener(RecoilAnim);
        weapon.onReload.AddListener(ReloadAnim);

        animator.SetFloat("ReloadTime", 1 / weapon.reloadTime);
        animator.SetFloat("FireRate", 1 / weapon.shootInterval);
    }

    void RecoilAnim()
    { 
        animator.Play("GunRecoilAnim");
    }

    void ReloadAnim()
    {
        animator.Play("GunReloadAnim");
    }
}
