
# Install and Use Nmap as a Port Scanner on Ubuntu

## **1. Install Nmap**
Open a terminal and run:
```bash
sudo apt update
sudo apt install nmap
```

## **2. Verify Installation**
Check if Nmap is installed by running:
```bash
nmap --version
```

## **3. Basic Usage for Port Scanning**

### **Scan a Single Host**
```bash
nmap <target-ip-or-hostname>
```
Example:
```bash
nmap 192.168.1.1
```

### **Scan Specific Ports**
```bash
nmap -p 22,80,443 <target-ip>
```

### **Scan a Range of Ports**
```bash
nmap -p 1-1000 <target-ip>
```

### **Full TCP Scan (Intense Scan)**
```bash
nmap -sT <target-ip>
```

### **Scan UDP Ports**
```bash
sudo nmap -sU <target-ip>
```

### **Scan for Open Services and Versions**
```bash
nmap -sV <target-ip>
```

### **Scan the Entire Network**
```bash
nmap 192.168.1.0/24
```

Here’s a guide on using Nmap to find vulnerabilities:

# Using Nmap to Find Vulnerabilities

Nmap can detect potential vulnerabilities by identifying open ports, outdated software, and misconfigured services.

---

## **1. Basic Vulnerability Scan**
```bash
nmap --script vuln <target-ip>
```
This runs built-in vulnerability detection scripts.

---

## **2. Detect Specific Vulnerabilities**

### **Heartbleed Vulnerability**
```bash
nmap --script ssl-heartbleed <target-ip>
```

### **Detect SMB Vulnerabilities**
```bash
nmap --script smb-vuln* <target-ip>
```
This covers various SMB vulnerabilities like EternalBlue.

### **HTTP DDoS Vulnerabilities**
```bash
nmap --script http-slowloris-check <target-ip>
```

---

## **3. Scan for Outdated Services**
```bash
nmap -sV --script=vulscan <target-ip>
```
Ensure you have the **vulscan** script library installed.

---

## **4. Brute Force Vulnerability Check**
```bash
nmap --script brute <target-ip>
```

---

## **5. Automating Common Security Checks**
```bash
nmap -p 1-65535 -sV -sC -oN scan_report.txt <target-ip>
```
- **-p 1-65535:** Scans all ports  
- **-sV:** Service detection  
- **-sC:** Default scripts  
- **-oN:** Save the report  

---

### **Note:**  
Nmap does not replace dedicated vulnerability scanners like Nessus or OpenVAS. Use responsibly on systems you own or have permission to scan.



To install and use the **vulscan** script library in Nmap on Ubuntu, follow these steps:


# **Installing the Vulscan Script Library for Nmap on Ubuntu**

## **1. Navigate to the Nmap Script Directory**
```bash
cd /usr/share/nmap/scripts
```

## **2. Clone the Vulscan Repository**
```bash
sudo git clone https://github.com/scipag/vulscan.git
```

## **3. Verify Installation**
Ensure the `vulscan` directory is present:
```bash
ls
```
You should see `vulscan` listed.

## **4. Update Nmap Script Database**
```bash
sudo nmap --script-updatedb
```

## **5. Running Nmap with Vulscan**
```bash
sudo nmap -sV --script=vulscan <target-ip>
```

## **6. Enhanced Usage with Vulscan Databases**
Vulscan can use vulnerability databases (like CVE). Ensure these databases are up-to-date by downloading them:
```bash
cd vulscan
sudo ./update-databases.sh
```

## **7. Example Scan**
```bash
sudo nmap -sV --script vulscan/vulscan.nse <target-ip>
```

---

### **Note:**  
Vulscan provides references to CVEs and other vulnerability sources but requires interpretation for accurate security assessments.
