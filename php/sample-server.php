<?php

/* 
     AlpineBits
     http://www.alpinebits.org/

     PHP code snippet to show programming the HTTPS layer (server)

     changelog:
     v. 2013-04 1.0 added ClientProtocolVersion and ClientID headers, minor changes
     v. 2012-05 1.0

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
