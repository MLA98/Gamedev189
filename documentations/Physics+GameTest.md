# Physics in Musky Defender

## Gravity System
Gravity Systems are retrieved from [Unity Asset Store](https://assetstore.unity.com/packages/tools/physics/orbital-gravity-movement-65682) by Author [Tiago Silva Duarte](https://assetstore.unity.com/publishers/22155). It provides oribital gravity by add force on rigid body:
```C#
        body.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);
```
and Keep The Rotation Quaternion of the player always look like standing on the planet:

```C#
        Vector3 gravityUp = (body.position - transform.position).normalized;
        Vector3 bodyUp = body.up;
        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * body.rotation;
        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50 * Time.deltaTime);
```
