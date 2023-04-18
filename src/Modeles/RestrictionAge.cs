namespace Modeles
{
    /// <summary>
    /// Enum pour la restriction d'age d'une émission : 
    /// Tout_public correcpond à un programme pour tout le monde
    /// dix correspond à un programme qui est déconseillé aux moins de 10 ans
    /// douze correspond à un programme qui est déconseillé aux moins de 12 ans
    /// seize correspond à un programme qui est déconseillé aux moins de 16 ans
    /// dix_huit correspond à un programme qui est déconseillé aux moins de 18 ans
    /// </summary>
    public enum RestrictionAge
    {
        Toutpublic,
        dix,
        douze,
        seize,
        dix_huit
    }
}
