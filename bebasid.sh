#!/bin/bash

# Instalasi hosts untuk Linux
# Only Tested on RHEL (CentOS, Fedora) and Debian (Ubuntu, Linux Mint, etc)
# Coded by Icaksh
# BEBASID

bebasid_banner(){
  echo " ____  _____ ____    _    ____ ___ ____  "
  echo "| __ )| ____| __ )  / \  / ___|_ _|  _ \ "
  echo "|  _ \|  _| |  _ \ / _ \ \___ \| || | | |"
  echo "| |_) | |___| |_) / ___ \ ___) | || |_| |"
  echo "|____/|_____|____/_/   \_\____/___|____/ "
  echo ""
  echo "==   SUPPORT INDONESIA NET NEUTRALITY  =="
  echo ""
}

# FUNCTION UNBLOCK WEBSITE
# USED TO UNBLOCK A WEBSITE WHAT YOU WANT WITH MODIFYING HOSTS FILE
unblock_hosts(){
sudo bash -c 'cat >> /etc/hosts-own'<<EOF

# [${domain^^}]
$ip $domain
EOF

sudo bash -c 'cat >> /etc/hosts'<<EOF

# [${domain^^}]
$ip $domain
EOF
}

# FUNCTION BLOCK
# USED TO BLOCK A WEBSITE WHAT YOU WANT WITH MODYFING HOSTS FILE
block_hosts(){
sudo bash -c 'cat >> /etc/hosts-own'<<EOF

# [${domain^^} - BLOCKED]
0.0.0.0 $domain
EOF

sudo bash -c 'cat >> /etc/hosts'<<EOF

# [${domain^^} - BLOCKED]
0.0.0.0 $domain
EOF
}

# RESTORE HOSTS FUNCTION
# FIX HOSTS FILE USING UNIVERSAL LINUX'S HOSTS FILE
restore_hosts(){
sudo bash -c "cat > /etc/hosts" <<EOF
127.0.1.1 myhostname
127.0.0.1 localhost

# The following lines are desirable for IPv6 capable hosts
::1 ip6-localhost ip6-loopback
fe00::0 ip6-localnet
ff00::0 ip6-mcastprefix
ff02::2 ip6-allrouters
ff02::1 ip6-allnodes
ff02::3 ip6-allhosts
EOF
}

# CURL + CHECKING THE RESULT OF CURL FUNCTION
# ONLY USING CURL IS BIG PROBLEM
# BECAUSE SOMEONE CAN FORGET ABOUT INTERNET CONNECTION
# AND DESTROYING THE HOSTS FILE
check_curl(){
  if sudo curl -o /etc/hosts https://raw.githubusercontent.com/gvoze32/bebasid/master/hosts; then
    sudo bash -c 'cat /etc/hosts-own >> /etc/hosts'
    sudo service network-manager restart
    echo ""
    echo "== BEBASID TELAH SUKSES TERPASANG =="
  else
    sudo mv /etc/hosts.bak-bebasid /etc/hosts
    echo ""
    echo "== BEBASID GAGAL DIPASANG =="
  fi
}

# GET DOMAIN'S IP ADDRESS
# THE URL IS FREE HOSTING SERVICE
# YOU CAN MODIF THE URL WITH YOUR'S SERVER/HOSTING
grep_ip(){
  ip=$(curl http://two-ply-mixtures.000webhostapp.com/?domain=$domain)
  if ! [[ "$ip" =~ ^(([1-9]?[0-9]|1[0-9][0-9]|2([0-4][0-9]|5[0-5]))\.){3}([1-9]?[0-9]|1[0-9][0-9]|2([0-4][0-9]|5[0-5]))$ ]]; then
  echo "$domain tidak dapat diunblock dikarenakan tidak ditemukan IP Address yang valid"
  exit 1
  fi
}

install_bebasid(){
  if [ -f /etc/hosts.bak-bebasid ]; then
    echo "Anda telah memasang BEBASID, silahkan uninstall BEBASID anda terlebih dahulu"
    exit 1
  else
    echo "Pastikan anda telah terkoneksi dengan internet dan telah terpasang cURL"
    read -p "Apakah anda yakin ingin memasang BEBASID? (Y/N): " confirm && [[ $confirm == [yY] || $confirm == [yY][eE][sS] ]] || exit 1
    sudo mv /etc/hosts /etc/hosts.bak-bebasid
    sudo touch /etc/hosts-own
    echo "== SEDANG MEMASANG BEBASID, PASTIKAN MENUNGGU HINGGA SELESAI =="
    echo ""
    check_curl
  fi
}

update_bebasid(){
  if [ -f /etc/hosts.bak-bebasid ]; then
    sudo rm -rf /etc/hosts
    echo "== SEDANG MEMASANG BEBASID, PASTIKAN MENUNGGU HINGGA SELESAI =="
    echo ""
    check_curl
    exit 1
  else
    echo "BACKUP HOSTS ASLI TIDAK DITEMUKAN, OPSI INSTALL BEBASID AKAN DIGUNAKAN"
    sudo mv /etc/hosts /etc/hosts.bak-bebasid
    echo "== SEDANG MEMASANG BEBASID, PASTIKAN MENUNGGU HINGGA SELESAI =="
    echo ""
    check_curl
    exit 1
  fi
}

uninstall_bebasid(){
  echo "== MEMERIKSA HOSTS BACKUP =="
  if [ -f /etc/hosts.bak-bebasid ]; then
    echo "HOSTS BACKUP DITEMUKAN, MEMULAI PENCOPOTAN BEBASID"
    sudo rm -rf /etc/hosts
    sudo rm -rf /etc/hosts-own
    sudo mv /etc/hosts.bak-bebasid /etc/hosts
    sudo service network-manager restart
    echo "== BEBASID TELAH SUKSES DICOPOT =="
  else
    echo "== HOSTS BACKUP TIDAK DITEMUKAN =="
    echo "PENCOPOTAN DENGAN HOSTS BACKUP DEFAULT LINUX"
    restore_hosts
    sudo service network-manager restart
    echo "== BEBASID TELAH SUKSES DICOPOT =="
  fi
}

fix_hosts(){
  sudo rm -rf "/etc/hosts"
  restore_hosts
  sudo service network-manager restart
  echo "FILE HOSTS TELAH DIUBAH KE DEFAULT, SILAHKAN MENCOBA PING"
  echo "APABILA MASIH TERJADI ERROR, MOHON CEK SECARA MANUAL FILE HOSTS"
  echo "UNTUK MENGGUNAKAN BEBASID KEMBALI, SILAHKAN MENGGUNAKAN FUNGSI UPDATE"
}


# INPUTING COMMAND
case $1 in
  "menu")
    bebasid_banner
    PS3='Pilih salah satu opsi: '
    echo ""
    options=("Install BEBASID" "Update BEBASID" "Uninstall BEBASID" "Fix Error DNS Not Resolved" "Keluar")
    select opt in "${options[@]}"
    do
      case $opt in
        "Install BEBASID")
          install_bebasid
          break
          ;;
        "Update BEBASID")
          update_bebasid
          break
          ;;
        "Uninstall BEBASID")
          uninstall_bebasid
          break
          ;;
        "Fix Error DNS Not Resolved")
          fix_hosts
          break
          ;;
        "Keluar")
          break
          ;;
        *)
          echo "Tidak ada opsi $REPLY"
          ;;
      esac
    done
    ;;
  "--help")
    bebasid_banner
    echo "Cara penggunaan:"
    echo "bebasid [command][website(untuk command block, unblock)]"
    echo ""
    echo "List command:"
    echo "menu      : Menampilkan opsi menu"
    echo "--help    : Menampilkan cara pemakaian dan list command"
    echo "block     : Memblokir akses website"
    echo "unblock   : Membuka akses website yang terkena blokir ipo-chan"
    echo "install   : Memasang hosts dari BEBASID"
    echo "update    : Membarukan hosts dari BEBASID"
    echo "uninstall : Mencopot hosts dari BEBASID"
    echo "fix       : Memperbaiki error DNS Not Resolved"
    echo ""
    echo "Apabila setelah pemasangan BEBASID terjadi error DNS Not Resolved,"
    echo "Mohon untuk segera menggunakan opsi fix, hal ini"
    echo "belum kami ketahui penyebabnya, yang pasti error terjadi karena"
    echo "ada kesalahan pada file hosts"
    ;;
  "unblock")
    if [ -z $2 ]; then
      echo "[website] tidak ditentukan"
      read -p "Masukkan website yang ingin diunblock: " domain
      read -p "Apakah sudah benar? (Y/N): " confirm && [[ $confirm == [yY] || $confirm == [yY][eE][sS] ]] || exit 1
      grep_ip
      unblock_hosts
    else
      domain=$2
      grep_ip
      unblock_hosts
    fi
    ;;
  "block")
    if [ -z $2 ]; then
      echo "[website] tidak ditentukan"
      read -p "Masukkan website yang ingin diblock: " domain
      read -p "Apakah sudah benar? (Y/N): " confirm && [[ $confirm == [yY] || $confirm == [yY][eE][sS] ]] || exit 1
      grep_ip
      unblock_hosts
    else
    domain=$2
    block_hosts
    fi
    ;;
  "install")
    install_bebasid
    ;;
  "update")
    update_bebasid
    ;;
  "uninstall")
    uninstall_bebasid
    ;;
  "fix")
    fix_hosts
    ;;
  *)
    echo "Command tidak ditemukan, beri perintah bebasid --help untuk bantuan"
    ;;
esac
