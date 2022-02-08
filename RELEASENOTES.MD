# Release Notes

### Release 2.1.3
Release date 2022-02-08

- **FRED sticker** design is changed:
  - colourisation is selectable separate for loco idenfification and functions.
  - Fonts are now smaller.
  - Functions now fist on backside of FRED, not above.
- **Spacing** added between *loco/wagon card*, *inventory card* and *FRED-sticker* to make cutting easier.
- **Owner signature marking** can be entered.
- **Uag class** freight wagon now displays with gray frame.

### Release 2.1.2
Release date 2022-02-07
- **FRED functions**, you can now select which functions that appears.
- **Loco DCC-address** can now be entered and displays on *FRED-sticker* and *inventory card*.
- **Loading instructions** can now be entered for cargo wagons.
- **Model weight** can now be entered for cargo wagons.
- **Owner image** can now be selected from your local computer.
- **Cargo wagon colours** for Ui and Ug classes updated. Thanks to Michael Bunka.

### Release 2.1.1
Release date 2022-02-05
- **FRED sticker** text overflow fixed.

### Release 2.1.0
Release 2022-02-04
- **Loco functions** can now be numbered freely, max functions are now 24 and only those with text are displayed on loco card.
- **Image upload** is now possible, you can select images from your disk, or still use links if you want.
- **Front image** now is resized correctly and does not overflow downwards into other fields.
- **Inventory card** has now smaller font size to not overflow content outside card.
- **Loco card** now has *Interoperability code* and *Country of registration*.
- **Zero value fields** are now mostly hidden, and only displays when value is greater than zero.
- **Empty value fields** are now some hidden, and only displays when having a text value.

### Release 2.0.6
Release date 2022-01-24
- **Owner marking** improved. Larger icon size and only relevant fields to enter are displayed.
- **Loco card** graphical errors corrected, and same *owner markings* as for cargo wagon.
- **Missing Translations** added.
- **Release notes** now have a link on the start page.

### Release 2.0.5
Release date 2022-01-20
- **Owner data** space extended to display longer email addresses. Thanks to Dag-Cato Skårvik for reporting this.
- **Owner icon** added as yet another way to specify owner identification on wagons. Thanks to Michael Bunka for the idea.
- **Model make and number** removed from wagon card, but still on inventory card. Thanks to Michael Bunka for the idea.
- **Region colours** instead of region names. Thanks to Michael Bunka for reporting names as problematic.
- **Epoch** will only be displayed on the card if you provide a value. Thanks to Michael Bunka for the idea.
- **UIC Control digit** now also appear on the inventory card. Thanks to Michael Bunka for the idea.

### Release 2.0.4
Release date 2022-01-19
This release adds wagon number labels that can be put on wagons as an easy way to have unique wagon numbers.
- **UIC checkdigit** is now calculated if *interoperability code*, *country number of wagon registration* and a *7-digit wagon number* is entered. 
You can still override this by entering wagon number including the control digit.
- **UIC wagon labels** are now included for cargo wagons. If your entered data does not comform to UIC-numbering, a simpler label is used.
- **Colour of wagon** controls background colour of the wagon labels.

### Release 2.0.3
Release date 2021-11-11
- **German** translation improved by Frank Hennies.
- **Units** for length, load weight and volume now are fixed to *m*, *t* and *m³* respectively.
- **Read me** updated.

### Release 2.0.2
Release date 2021-11-07
- **Resizing** of wagon heading improved to fit text better.
- **Home station** label now also displays label in language of home country for DE, DK, NO and SE.

### Release 2.0.1
Release date: 2021-11-03
- **Owner marking** is optional.

### Release 2.0.0
Release date: 2021-10-30
- **Freigh wagon card** can now be created and printed.
- **Refined card layout** to make loco and wagon card as similar as possible.
- **Norwegian** also supported besides English, German, Danish and Swedish.
- **Update to .NET 6.0** 

### Release 1.0.4
Release date 2021-07-04
- **Up- and download of loco data** in JSON to/from your local computer. 

### Release 1.0.3
Release date 2021-07-02
- **Improved German translations**. Thanks to Gerhard Voss!
- **Release notes** committed to repository.
- **About page** updated with links to *Release notes*, *Source code* and *Issues*.

### Release 1.0.2
Release date 2021-07-01
- **FRED-sticker** now contains F0-F8 and only positions that have explanatory text.
- **Missing translations** of button texts added.

### Release 1.0.1
Release date 2021-06-30
- **Reset loco form** button added.
- **Refined translations** and spelling corrections.

### Release 1.0.0
Release date 2021-06-30
- **First release**