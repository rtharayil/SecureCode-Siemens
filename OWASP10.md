
# OWASP Top 10: A Detailed Overview
notes by Ranjith Tharayil

The Open Web Application Security Project (OWASP) is a nonprofit foundation that works to improve the security of software. One of its most well-known projects is the **OWASP Top 10**, a standard awareness document that highlights the most critical security risks to web applications. It is updated periodically to reflect the evolving threat landscape and is widely used by developers, security professionals, and organizations to prioritize and address vulnerabilities in their applications.

The OWASP Top 10 is based on data from various sources, including vulnerability databases, security experts, and real-world application testing. Below is a detailed explanation of the **OWASP Top 10 (2021 edition)**, which is the latest version as of my knowledge cutoff in October 2023.

---

## 1. **Broken Access Control**
**Description**: Access control enforces policies to ensure users cannot act outside their intended permissions. Broken access control occurs when restrictions on authenticated users are not properly enforced, allowing attackers to access unauthorized functionality or data.

**Examples**:
- Bypassing access control checks by modifying URLs or API requests.
- Elevating privileges to perform actions as an admin or another user.
- Accessing sensitive files or directories without proper authorization.

**Impact**: Attackers can exploit broken access control to view, modify, or delete sensitive data, compromise user accounts, or take over administrative functions.

**Prevention**:
- Implement role-based access control (RBAC).
- Deny access by default and enforce access controls on every request.
- Regularly test access control mechanisms.

---

## 2. **Cryptographic Failures**
**Description**: Cryptographic failures (formerly known as "Sensitive Data Exposure") occur when sensitive data is not properly protected using encryption or hashing, making it vulnerable to theft or exposure.

**Examples**:
- Storing passwords in plaintext or using weak hashing algorithms.
- Transmitting sensitive data over unencrypted channels (e.g., HTTP).
- Using outdated or insecure cryptographic protocols (e.g., SSL/TLS with weak ciphers).

**Impact**: Attackers can steal sensitive data such as passwords, credit card numbers, or personal information, leading to identity theft, financial loss, or compliance violations.

**Prevention**:
- Use strong encryption algorithms (e.g., AES, SHA-256).
- Encrypt data in transit (e.g., HTTPS) and at rest.
- Avoid deprecated protocols like SSL and TLS 1.0/1.1.

---

## 3. **Injection**
**Description**: Injection flaws occur when untrusted data is sent to an interpreter as part of a command or query, leading to unintended execution of malicious commands.

**Examples**:
- SQL Injection: Injecting malicious SQL queries to manipulate databases.
- Command Injection: Executing arbitrary commands on the server.
- Cross-Site Scripting (XSS): Injecting malicious scripts into web pages viewed by other users.

**Impact**: Attackers can steal data, modify or delete database records, execute commands on the server, or take control of the application.

**Prevention**:
- Use parameterized queries or prepared statements.
- Validate and sanitize all user inputs.
- Employ output encoding to prevent XSS.

---

## 4. **Insecure Design**
**Description**: Insecure design refers to flaws in the architecture or design of an application that make it inherently vulnerable to attacks. This is distinct from implementation flaws, as it involves missing or inadequate security controls at the design stage.

**Examples**:
- Lack of threat modeling during the design phase.
- Failing to define security requirements.
- Designing systems without considering authentication, authorization, or encryption.

**Impact**: Attackers can exploit design flaws to bypass security controls, gain unauthorized access, or cause other security breaches.

**Prevention**:
- Integrate security into the software development lifecycle (SDLC).
- Perform threat modeling and risk assessments.
- Define and enforce security requirements.

---

## 5. **Security Misconfiguration**
**Description**: Security misconfiguration occurs when security settings are not properly defined, implemented, or maintained, leaving the application vulnerable to attacks.

**Examples**:
- Using default credentials or configurations.
- Enabling unnecessary features or services.
- Failing to apply security patches or updates.

**Impact**: Attackers can exploit misconfigurations to gain unauthorized access, leak sensitive data, or compromise the application.

**Prevention**:
- Follow secure configuration guidelines for all components.
- Disable unnecessary features and services.
- Regularly review and update configurations.

---

## 6. **Vulnerable and Outdated Components**
**Description**: Using components (e.g., libraries, frameworks, or plugins) with known vulnerabilities can expose the application to attacks.

**Examples**:
- Using outdated versions of libraries or frameworks.
- Failing to monitor for new vulnerabilities in dependencies.
- Not applying patches or updates in a timely manner.

**Impact**: Attackers can exploit known vulnerabilities to compromise the application or its underlying infrastructure.

**Prevention**:
- Regularly update and patch all components.
- Use tools to monitor for vulnerabilities in dependencies.
- Remove unused or unnecessary components.

---

## 7. **Identification and Authentication Failures**
**Description**: Authentication and session management flaws occur when an application fails to properly verify the identity of users or manage their sessions securely.

**Examples**:
- Weak or default passwords.
- Session fixation attacks.
- Lack of multi-factor authentication (MFA).

**Impact**: Attackers can impersonate users, hijack sessions, or gain unauthorized access to the application.

**Prevention**:
- Implement strong password policies and MFA.
- Use secure session management practices.
- Protect against brute force and credential stuffing attacks.

---

## 8. **Software and Data Integrity Failures**
**Description**: This category involves failures to protect the integrity of software and data, often due to insecure CI/CD pipelines or reliance on untrusted sources.

**Examples**:
- Using untrusted third-party components.
- Failing to verify the integrity of updates or patches.
- Allowing unauthorized modifications to code or data.

**Impact**: Attackers can introduce malicious code, compromise data integrity, or disrupt application functionality.

**Prevention**:
- Use digital signatures to verify the integrity of software.
- Secure CI/CD pipelines and enforce code reviews.
- Monitor for unauthorized changes.

---

## 9. **Security Logging and Monitoring Failures**
**Description**: Inadequate logging and monitoring make it difficult to detect and respond to security incidents in a timely manner.

**Examples**:
- Failing to log security-relevant events.
- Not monitoring logs for suspicious activity.
- Storing logs in an insecure manner.

**Impact**: Attackers can exploit vulnerabilities without detection, prolonging their access and increasing the damage.

**Prevention**:
- Implement comprehensive logging of security events.
- Use automated tools to monitor logs for anomalies.
- Protect logs from tampering or unauthorized access.

---

## 10. **Server-Side Request Forgery (SSRF)**
**Description**: SSRF occurs when an attacker can trick the server into making unauthorized requests to internal or external systems.

**Examples**:
- Exploiting a web application to access internal services.
- Bypassing firewalls or access controls.
- Exfiltrating sensitive data from internal systems.

**Impact**: Attackers can access sensitive data, exploit internal systems, or escalate privileges.

**Prevention**:
- Validate and sanitize user inputs.
- Restrict outgoing requests from the server.
- Use network segmentation to limit access to internal systems.

---

## Conclusion
The OWASP Top 10 is an essential resource for understanding and mitigating the most critical security risks in web applications. By addressing these vulnerabilities, organizations can significantly reduce the likelihood of a security breach and protect their users' data. Regular security assessments, secure coding practices, and continuous monitoring are key to maintaining a robust security posture.

For the latest updates and detailed guidance, always refer to the official OWASP website: [https://owasp.org](https://owasp.org).

