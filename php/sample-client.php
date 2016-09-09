<?php

/* 
     AlpineBits
     http://www.alpinebits.org/

     PHP code snippet to show programming the HTTPS layer (client)

     changelog:
     v. 2015-07b 1.0 changed ClientProtocolVersion to 2015-07n
     v. 2013-04 1.0 added ClientProtocolVersion and ClientID headers, minor changes 
     v. 2012-05 1.0

     Copyright 2013 AlpineBits Alliance

     Licensed under the Apache License, Version 2.0 (the "License");
     you may not use this file except in compliance with the License.
     You may obtain a copy of the License at

         http://www.apache.org/licenses/LICENSE-2.0

     Unless required by applicable law or agreed to in writing, software
     distributed under the License is distributed on an "AS IS" BASIS,
     WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
     See the License for the specific language governing permissions and
     limitations under the License.
*/

$cu = curl_init("http://www.example.com/alpinebits/sample-server.php");

curl_setopt($cu, CURLOPT_RETURNTRANSFER,    true);
curl_setopt($cu, CURLOPT_POST,              true);
curl_setopt($cu, CURLOPT_HTTPAUTH,          CURLAUTH_BASIC);
                                            # in production should be CURLPROTO_HTTPS only
curl_setopt($cu, CURLOPT_PROTOCOLS,         CURLPROTO_HTTP | CURLPROTO_HTTPS);
curl_setopt($cu, CURLOPT_USERPWD,           "chris:secret");
    
curl_setopt($cu, CURLOPT_HTTPHEADER,        array("X-AlpineBits-ClientProtocolVersion: 2015-07b",
                                                  "X-AlpineBits-ClientID: sample-client.php v. 2015-07b 1.0"));

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
