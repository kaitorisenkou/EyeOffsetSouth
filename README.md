Class library for Rimworld mod.
This library adds a modExtension that works like <eyeOffsetEastWest>, but only when south direction.
```
  <HeadTypeDef ParentName="AverageBase">
    <defName>Head_Sample_EyeOffsetSouth</defName>
    <graphicPath>Things/Pawn/Humanlike/Heads/Male/Male_Average_Normal</graphicPath>
    <selectionWeight>0</selectionWeight>
    <randomChosen>false</randomChosen>
    <gender>None</gender>
    <eyeOffsetEastWest>(0.18, 0, 0.17)</eyeOffsetEastWest>
    <modExtensions>
      <li Class="EyeOffsetSouth.ModExtension_EyeOffsetSouth">
        <offset>(0, 0, 1.0)</offset>
      </li>
    </modExtensions>
  </HeadTypeDef>
```
