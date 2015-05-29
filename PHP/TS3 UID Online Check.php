<?php
#Requires the ts3admin.class (http://ts3admin.info)
function isUIDConnected($uid)
{
 global $ts3;
 $userTSName = $ts3->clientGetNameFromUid($uid);
 if($userTSName["success"] == false) return 0;
 $clients = $ts3->clientList();
 foreach($clients['data'] as $client) {
  if($client['client_nickname'] == $userTSName["data"]["name"]) return 1; 
 }
}
?>