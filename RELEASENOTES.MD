# Release Notes
>When you use a new release, it is recommended that you do a *hard refresh* in your browser, to ensure that you get the latest styles applied.

>A note when printing: In browser print dialog, select to print *background graphics* for best result. Otherwise, all coloured backgrounds will not print.
## Release 2.1.28
Release date 2024-01-04
- **Bug fix** of owner name in QR-code. Thanks to Herbert Stadler for notifying this.
## Release 2.1.27
Release date 2023-12-27
- **Fix** of text lenghts.
## Release 2.1.26
Release date 2023-12-18
- **UIC main class** is now displayed on freight wagon cards.
- **UIC main class** can be spedified if wagon class is before UIC-classes was introduced.
- **DCC address** is now also displayed on loco card.
- **INTERFRIGO** can now be checked for wagons that fulfils this interoperability.
## Release 2.1.25
Release date 2023-05-29
- **Inventory number** can now be given in combination with any owner marking.
## Release 2.1.24
Release date 2023-05-28
- **Bug fix** of innsue #24 owner marking not visible on loco card.
## Release 2.1.23
Release date 2023-05-10
- **Engine power** translations corrected. Thanks to Martin Pischky for the suggestion.
## Release 2.1.22
Release date 2023-04-21
- **Operator logo** can now be uploaded and replaces *operator signature* on the 
FRED-sticker. Thanks to Søren Bendtsen and Jan Aude for the idea.
- **Model image** now also appears on the FRED-sticker. Thanks to Jan Aude for the idea.
- **Wheel type** of the model can now be specified. Thanks to Søren Bendtsen for the idea.
It's a free text, but typically you will type *NEM*, *RP25* or other standard name
appropriate for the scale and theme of your loco.

## Release 2.1.21
Release date 2023-03-01
- **Fixed printing** issues where inventory card overlaps wagon card.
- **Extra FRED** sticker is now optional.
- **Wagon Card** now have options to select what to print.
- **Old app version** should now be detected.

## Release 2.1.20
Release date 2023-02-28
- **Firewall fix** to make the application work also behind (some) firewalls.
Thanks to Halvor Sannæs for testing it in Arendal.

## Release 2.1.19
Release date 2022-12.17
- **Bug fix** of misalignment of *inventory card* in some browsers printing preview.
Thanks to Johannes Edvinsson for reporting this.
- **Bug fix** of loading JSON with *owner* for wagons.

## Release 2.1.18
Release date 2022-11-21
- **Upgrade** to .NET 7.
- **Max upload file size** increased to 4MB.

## Release 2.1.17
Release date 2022-10-31
- **Double FRED labels** for locos. Suggested by Michael Homscheidt.
- **Square meters** added as load description for wagons, issue #17. Suggested by Tore Urvik.
- **JSON data** now contains owner name when downloaded and only if you change the default name, issue #15. Suggested by Tore Urvik.
- **Bug fix** of issue #16 where wagon origin and model images were swapped. Thanks to Benny Tjäder for reporting this.
- **Bug fix** of unit for *load limit* and *load volume*.

## Release 2.1.16
Release date 2022-09-14
- **FRED sticker** format correction that gives room for more Functions.

## Release 2.1.15
Release date 2022-09-12
- **Passenger Wagon Colours** corrected to conform to FREMO standard.
- **DCC Address Calculator** added.
## Release 2.1.14
Release date 2022-09-08
- **References** page updated.
## Release 2.1.13
Release date 2022-07-18
- **Security update** with latest security patches from Microsoft.
## Release 2.1.12
Release date 2022-07-02
- **QR-Codes** added on loco- and wagon cards. QR-code also on FRED-sticker. QR-code contains *loco address*, *owner's name*, *UIC-number*, and *label*.
If a value is not provided, it won't show up in the QR-code.
The content of the QR-code is formatted as JSON, which also makes it machine readable.
## Release 2.1.11
Release date 2022-06-27
- **Bug fox** of translation and coloring of wagons.
## Release 2.1.10
Release date 2022-05-25
- **Print options** for loco card let you choose what to print.
## Release 2.1.9
Release date 2022-05-22
- **Passenger wagon cards** added. Note that passenger coaches classes A-F will have blue frame. 
Please give feedback if you need any customisations regading frame colors for passenger coaches.
## Release 2.1.8
Release date 2022-05-04
- **Bug fix** of JSON-files too large when uploading.

## Release 2.1.7
Release date 2022-04-05
- **Layout change** in loco card to avoid line breaks.
- **Removal of images** selected from local drives. 
- **Bug fix** of *model*- and *original* image swapped. 

## Release 2.1.6
Release date 2022-02-23
- **Bug fix** of max heigh of model page image.

## Release 2.1.5
Release date 2022-02-12
- **Reference page** added, describing international standards for numbering and classification of locos and wagons.
- **EVN 12-digit number** for loco numering now works. If you specify an inperoperability code, a country number and a 7-digit loco number, 
the checkdigit will automatically be added.
- **Bug fix** of check digit displaying 10 should be 0.

## Release 2.1.4
Release date 2022-02-09
- **Card dimensions** adapted to show more of the coloured frame. 
The colour frame is now 1 mm wider on all sides than A6 (105x148mm), 
which will result in a 4mm coloured frame after cutting to A6. 
This made the content of the card a bit smaller.
- **Model images** now is clipped to fit within box, and still have room for *loading instructions*. 
Note that images should have 8:3 in proportion for best view, otherwise some part of the image will be clipped and not visible.

## Release 2.1.3
Release date 2022-02-08

- **FRED sticker** design is changed:
  - Colourisation is selectable separate for loco identification and functions.
  - Fonts are now smaller.
  - Functions now on backside of FRED, not above.
- **Spacing** added between *loco/wagon card*, *inventory card* and *FRED-sticker* to make cutting easier.
- **Owner signature marking** can be entered.
- **Uag class** freight wagon now displays with gray frame.

## Release 2.1.2
Release date 2022-02-07
- **FRED functions**, you can now select which functions that appears.
- **Loco DCC-address** can now be entered and displays on *FRED-sticker* and *inventory card*.
- **Loading instructions** can now be entered for cargo wagons.
- **Model weight** can now be entered for cargo wagons.
- **Owner image** can now be selected from your local computer.
- **Cargo wagon colours** for Ui and Ug classes updated. Thanks to Michael Bunka.

## Release 2.1.1
Release date 2022-02-05
- **FRED sticker** text overflow fixed.

## Release 2.1.0
Release 2022-02-04
- **Loco functions** can now be numbered freely, max functions are now 24 and only those with text are displayed on loco card.
- **Image upload** is now possible, you can select images from your disk, or still use links if you want.
- **Front image** now is resized correctly and does not overflow downwards into other fields.
- **Inventory card** has now smaller font size to not overflow content outside card.
- **Loco card** now has *Interoperability code* and *Country of registration*.
- **Zero value fields** are now mostly hidden, and only displays when value is greater than zero.
- **Empty value fields** are now some hidden, and only displays when having a text value.

## Release 2.0.6
Release date 2022-01-24
- **Owner marking** improved. Larger icon size and only relevant fields to enter are displayed.
- **Loco card** graphical errors corrected, and same *owner markings* as for cargo wagon.
- **Missing Translations** added.
- **Release notes** now have a link on the start page.

## Release 2.0.5
Release date 2022-01-20
- **Owner data** space extended to display longer email addresses. Thanks to Dag-Cato Skårvik for reporting this.
- **Owner icon** added as yet another way to specify owner identification on wagons. Thanks to Michael Bunka for the idea.
- **Model make and number** removed from wagon card, but still on inventory card. Thanks to Michael Bunka for the idea.
- **Region colours** instead of region names. Thanks to Michael Bunka for reporting names as problematic.
- **Epoch** will only be displayed on the card if you provide a value. Thanks to Michael Bunka for the idea.
- **UIC Control digit** now also appear on the inventory card. Thanks to Michael Bunka for the idea.

## Release 2.0.4
Release date 2022-01-19
This release adds wagon number labels that can be put on wagons as an easy way to have unique wagon numbers.
- **UIC checkdigit** is now calculated if *interoperability code*, *country number of wagon registration* and a *7-digit wagon number* is entered. 
You can still override this by entering wagon number including the control digit.
- **UIC wagon labels** are now included for cargo wagons. If your entered data does not comform to UIC-numbering, a simpler label is used.
- **Colour of wagon** controls background colour of the wagon labels.

## Release 2.0.3
Release date 2021-11-11
- **German** translation improved by Frank Hennies.
- **Units** for length, load weight and volume now are fixed to *m*, *t* and *m³* respectively.
- **Read me** updated.

## Release 2.0.2
Release date 2021-11-07
- **Resizing** of wagon heading improved to fit text better.
- **Home station** label now also displays label in language of home country for DE, DK, NO and SE.

## Release 2.0.1
Release date: 2021-11-03
- **Owner marking** is optional.

## Release 2.0.0
Release date: 2021-10-30
- **Freigh wagon card** can now be created and printed.
- **Refined card layout** to make loco and wagon card as similar as possible.
- **Norwegian** also supported besides English, German, Danish and Swedish.
- **Update to .NET 6.0** 

## Release 1.0.4
Release date 2021-07-04
- **Up- and download of loco data** in JSON to/from your local computer. 

## Release 1.0.3
Release date 2021-07-02
- **Improved German translations**. Thanks to Gerhard Voss!
- **Release notes** committed to repository.
- **About page** updated with links to *Release notes*, *Source code* and *Issues*.

## Release 1.0.2
Release date 2021-07-01
- **FRED-sticker** now contains F0-F8 and only positions that have explanatory text.
- **Missing translations** of button texts added.

## Release 1.0.1
Release date 2021-06-30
- **Reset loco form** button added.
- **Refined translations** and spelling corrections.

## Release 1.0.0
Release date 2021-06-30
- **First release**