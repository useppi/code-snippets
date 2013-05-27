<?php

/* 
     AlpineBits
     http://www.alpinebits.org/

     PHP code snippet to show programming the HTTPS layer (server)

     changelog:
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

if (!isset($_SERVER['PHP_AUTH_USER'])) {
    header('WWW-Authenticate: Basic realm="AlpineBits demo server"');
    header('HTTP/1.0 401 Authorization Required)');
    echo 'ERROR:no user/pass';
    exit;
}

if ( ! ( isset($_SERVER['PHP_AUTH_USER']) && $_SERVER['PHP_AUTH_USER'] == "chris" ) ||
     ! ( isset($_SERVER['PHP_AUTH_PW'])   && $_SERVER['PHP_AUTH_PW']   == "secret")
   ) {
    header('HTTP/1.0 401 Authorization Required');
    echo 'ERROR:wrong user/pass';
    exit;
}

$headers = apache_request_headers();

echo "Nice to meet you, " . $_SERVER['PHP_AUTH_USER'] . ".\n";
$ver = "legacy";
foreach ($headers as $key => $val) {
    if ($key == "X-AlpineBits-ClientProtocolVersion") {
        $ver = $val;
    }
    if ($key == "X-AlpineBits-ClientID") {
        echo "Your client ID is '" . $val . "'.\n";
    }
}
echo "Your client protocol version is '" . $ver . "'.\n";
?>
