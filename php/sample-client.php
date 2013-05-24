<?php

/* 
     AlpineBits
     http://www.alpinebits.org/

     PHP code snippet to show programming the HTTPS layer (client)

     changelog:
     v. 2013-04 1.0 added ClientProtocolVersion and ClientID headers, minor changes 
     v. 2012-05 1.0

*/

$cu = curl_init("http://www.example.com/alpinebits/sample-server.php");

curl_setopt($cu, CURLOPT_RETURNTRANSFER,    true);
curl_setopt($cu, CURLOPT_POST,              true);
curl_setopt($cu, CURLOPT_HTTPAUTH,          CURLAUTH_BASIC);
                                            # in production should be CURLPROTO_HTTPS only
curl_setopt($cu, CURLOPT_PROTOCOLS,         CURLPROTO_HTTP | CURLPROTO_HTTPS);
curl_setopt($cu, CURLOPT_USERPWD,           "chris:secret");
    
curl_setopt($cu, CURLOPT_HTTPHEADER,        array("X-AlpineBits-ClientProtocolVersion: 2013-04",
                                                  "X-AlpineBits-ClientID: sample-client.php v. 2013-04 1.0"));

$data = array(
    "action" => "OTA_HotelAvailNotif",
    "msg"   => file_get_contents("sample-FreeRooms-OTA_HotelAvailNotifRQ.xml")
);

curl_setopt($cu, CURLOPT_POSTFIELDS, $data);

$output = curl_exec($cu);
$info = curl_getinfo($cu);
curl_close($cu);

if ($info["http_code"] != 200) {
    echo "Oops: got http status code " . $info["http_code"] . "<br>\n";
}

echo "Server said:<br>\n";
echo "<pre>";
echo $output;
echo "</pre>";

?>
