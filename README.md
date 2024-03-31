# G1N Font Editor
This program allows to create or modify the .g1n font format used in some Koei Tecmo games.

Requires [.NET Framework v4.8.](https://dotnet.microsoft.com/en-us/download/dotnet-framework)
[Download latest release.](https://github.com/lehieugch68/G1N-Font-Editor/releases)

## Features
- Create a new .g1n font or modify an existing one.
- Automatically import glyph metrics and draw their bitmaps from TrueType fonts.
- Export/import glyph bitmaps and manually modify their metrics.

## Guide
G1N is a font format utilized in various Koei Tecmo games like Fatal Frame, Nioh, and Wo Long, etc. This program aims to simplify the process of modifying that format.
<p align="center"><img src="https://i.imgur.com/OoEHaZq.png"></p>

### I. Convert from TrueType Font
- Create new or open existing an .g1n font via **File → New** or **File → Open**. A G1N font can contain many subfonts (**pages**). If you create a new font, you should keep the number of pages the same as the font used in the game.
- If the original .g1n file contains multiple pages, identify the specific page containing the font you want to modify and switch to that page.
- Choose the TrueType font (.ttf) you want to convert, customize its size and style, and proceed to input the characters you desire to include in the font.
- Click **Generate Bitmap from TrueType Font** and wait for the program to process it, then save the .g1n file.

*Note: The G1N format utilizes one byte to store each value, you should not set the font size too large (should be less than **127**).*

### II. Modify Glyphs Manually

#### 1. Glyph Metrics
Some converted TrueType fonts may not display properly in the game. To address this, you can manually adjust their glyph metrics by left-clicking on a specific character on the bitmap to modify it, or adjusting the parameters in the **Glyph Options** section to apply to all glyphs.

There are three editable metrics:
- **Baseline**: The baseline is the invisible line upon which letters rest. Put simply, if you want a character to be positioned higher, increase it, and vice versa.
- **XOffset**: XOffset is a value that specifies the horizontal shift of each character. Increasing the XOffset will shift the character to the right, and vice versa.
- **XAdvance**: XAdvance is a value that determines the horizontal distance that needs to be advanced after displaying each character. It is almost the same as width, but is affected by XOffset.

*Note: The G1N format utilizes one byte to store each value, these metrics cannot be greater than **127**.*
<p align="center"><img src="https://i.imgur.com/uWVq1KP.png"></p>

For example, the generated characters are positioned quite low, so I increased the Baseline value by 20 to align them with the icon:
<p align="center"><img src="https://i.imgur.com/h7BJ1zj.png"></p>

#### 2. Add/Remove Glyphs

If you do not want to automatically generate from TrueType font, you can manually add the desired characters via **Edit → Add Glyph** or by right-clicking on an empty space on the bitmap.
The program will prompt you to select an image for the glyph and input the necessary values. The image should have a transparent background and must not exceed the size of 127x127 pixels.

*Note: The Character field can only accept characters within the range of 0x00 to 0xFFFF. If the character you want to add is outside this range, you should assign it to an unused character.*
<p align="center"><img src="https://i.imgur.com/nGGrxN6.png"></p>

To remove a glyph, right-click the character on the bitmap and select **Remove Glyph**.
<p align="center"><img src="https://i.imgur.com/ptQ2Sbf.png"></p>

#### 3. Import/Export Bitmap Images

Similar to removing a glyph, you can right-click a character on a bitmap to import or export its bitmap.

### III. Customize Color

In addition, you can also customize the color of the characters in the game.
<p align="center"><img src="https://i.imgur.com/5Mg02xQ.png"></p>

## Issues

If there are any problems with the program or there is an unsupported G1N format, feel free to create an [issue](https://github.com/lehieugch68/G1N-Font-Editor/issues).

## Helpful Links
- Vietnamese Guide.
- [VietHoaGame Discord](https://viethoagame.com/).

## Special Thanks:
- [oblivion](https://viethoagame.com/members/oblivion.4/)
- [haianh97](https://viethoagame.com/members/haianh97.441/)