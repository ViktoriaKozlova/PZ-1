<?xml version="1.0" encoding="utf-8" ?>
<xsl:transform version="1.0"
               xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:hot="http://hotel.com">

    <xsl:template match="/">
        <html>
            <body>
                <h1>Orders</h1>
                <table border="1">
                    <tr bgcolor="#ff4400">
                        <th></th>
                        <th>OrderId</th>
                        <th>Status</th>
                        <th>Room</th>
                        <th>Spa</th>
                        <th>Menu</th>
                    </tr>
                    <xsl:for-each select="hot:orders/hot:order">
                        <xsl:if test="hot:orderStatus &gt; New">
                            <tr bgcolor="#ff7d4d">
                                <td><xsl:value-of select="@id"/></td>
                                <td><xsl:value-of select="hot:room"/></td>
                                <td><xsl:value-of select="hot:spa"/></td>
                                <td><xsl:value-of select="hot:menu"/></td>
                            </tr>
                        </xsl:if>
                    </xsl:for-each>
                    
                </table>

            </body>
        </html>
    </xsl:template>

</xsl:transform>